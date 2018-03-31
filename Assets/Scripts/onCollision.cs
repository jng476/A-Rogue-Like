using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onCollision : MonoBehaviour {

	//destroys players projectile on impact.
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.name != "Player") {
			Destroy (this.gameObject);
		}

	}
}
