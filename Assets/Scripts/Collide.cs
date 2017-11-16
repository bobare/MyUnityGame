using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collide : MonoBehaviour {
	//public Bird other;
	//public Bird EndScene;
	void OnCollisionEnter2D(Collision2D coll)
	{
	// Restart
		//other.EndScene();
		//Bird.GetComponent<Bird>().EndScene();
		//Bird = gameObject.GetComponent<Bird>();
		SceneManager.LoadScene("scene");
		//Bird.EndScene;
	}

}
