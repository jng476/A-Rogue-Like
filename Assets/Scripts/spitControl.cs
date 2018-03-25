using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spitControl : MonoBehaviour {

	public Vector2 speed;
	Rigidbody2D spit;
	// Use this for initialization
	void Start () {
		spit = GetComponent<Rigidbody2D>();
		spit.velocity = speed;
	}
	
	// Update is called once per frame
	void Update () {
		spit.velocity = speed; 
	}
}
