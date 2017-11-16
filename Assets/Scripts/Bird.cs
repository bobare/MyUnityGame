using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour {
	// Movement speed
	public float speed = 2;
	// Flap force
	public float force = 300;
	// Interval of generating points
	public float spawnTime = 3f;
	// Interval for generating ground
	public float groundSpawnTime = 18f;
	// Display of counted points
	public Text countText;
	// Final counting points storage
	private int count;
	// Display Pause
	public Text Escape;
	public Text end;
	public Text fin;

	// 
	public Transform point;
	public Transform obstacle;
	public Transform ground;

	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
		// Fly towards the right
		GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
		//set total points to zero
		count = 0;
		//call the function to set the counted points
		SetCountText ();
		Escape.text = "";
		fin.text = "";
		/*call the Spawn function after a delay of spawnTime 
		and then continue to call after the same amount of time*/
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
		/*call the GroundSpawn function after a delay of GroundSpawnTime 
		and then continue to call after the same amount of time*/
		InvokeRepeating ("GroundSpawn", groundSpawnTime, groundSpawnTime);
	}
	
	// Update is called once per frame
	void Update () {
		//check if input is a spceabar or a click
		if ((Input.GetKeyDown(KeyCode.Space)) || (Input.GetMouseButtonDown(0)))
			//if true add a force
			GetComponent<Rigidbody2D> ().AddForce (Vector2.up * force);
		//check if input is escape key
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			//if true check if time is running
			if (Time.timeScale == 1) {
				//if time is running, stop time
				Time.timeScale = 0;
				//display PAUSE
				Escape.text = "PAUSE";
				//if time is not running
			} else if (Time.timeScale == 0) 
			{
				//resume time
				Time.timeScale = 1;
				//remove the PAUSE display
				Escape.text = "";
			}
		}
			
	}

	//bird colliding with other objects
	void OnTriggerEnter2D(Collider2D other)
	{
		//bird colliding with a point
		if (other.gameObject.CompareTag ("point")) {
			//make it disappear
			other.gameObject.SetActive (false);
			//add a point
			count = count + 1;
			SetCountText ();
		} else if (other.gameObject.CompareTag ("roof")) 
			EndScene ();
	}
	public void EndScene ()
	{
		gameObject.SetActive (false);
		end.text = count.ToString ();
		fin.text = "YOUR SCORE";
		Time.timeScale = 0;
		SceneManager.LoadScene ("scene");
	}

	//Spawn function
	void Spawn ()
	{
		float y = Random.Range (-2, 4);
		float x = gameObject.transform.position.x + 24;
		Instantiate(point, new Vector2(x, y), Quaternion.identity);
		float up = 6 + y;
		float down = y - 6;
		Instantiate (obstacle, new Vector2(x, up), Quaternion.identity);
		Instantiate (obstacle, new Vector2(x, down), Quaternion.identity);
		x = x + 6;
	}
	void GroundSpawn ()
	{
		float x = gameObject.transform.position.x + 32;
		Instantiate (ground, new Vector2(x, -6), Quaternion.identity);
		x = x + 64;
	}

	void SetCountText ()
	{
		countText.text = count.ToString ();
	}
}
