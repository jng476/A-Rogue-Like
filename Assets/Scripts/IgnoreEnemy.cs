using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreEnemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Physics2D.IgnoreLayerCollision(9, 10);
		Physics2D.IgnoreLayerCollision(8, 10);
		Physics2D.IgnoreLayerCollision(10, 10);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
