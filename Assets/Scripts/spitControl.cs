using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spitControl : MonoBehaviour {

	public Vector2 speed; //players projectile fire speed.
	Rigidbody2D spit; //Prefab of projectile.
	//Gets component and sets speed of how fast to move.
	void Start () {
		spit = GetComponent<Rigidbody2D>();
		spit.velocity = speed;
	}
	
	// Update is called once per frame
	void Update () {
		spit.velocity = speed; 
	}
}
