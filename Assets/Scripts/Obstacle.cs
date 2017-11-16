using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {
	// Movement Speed (0 means don't move)
	public float speed = 0;

	// Switch Movement every x seconds
	public float switchTime = 2;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D> ().velocity = Vector2.up * speed;

		//Swith every few seconds
		InvokeRepeating("Switch", 0, switchTime);
	}
	
	// Update is called once per frame
	void Switch () {
		GetComponent<Rigidbody2D> ().velocity *= -1;
	}
}
