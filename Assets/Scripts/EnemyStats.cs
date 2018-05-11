﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour {

	public int enemyHealth; //Enemies Health.


	//Checks if the Enemy is dead.
	void Update () {
		if (enemyHealth <= 0) {
			Destroy (this.gameObject);

		}
	}
	//If the Enemy is hit by the players projectile take damage.
	void OnCollisionEnter2D(Collision2D obj){
		if (obj.gameObject.tag == "Spit") {
			enemyHealth --;

		}
	}
}
