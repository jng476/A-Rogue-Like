using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour {

	public int enemyHealth = 1;
	// Use this for initialization
	void Start () {
		enemyHealth = 3;
	}

	// Update is called once per frame
	void Update () {
		if (enemyHealth <= 0) {
			Destroy (this.gameObject);

		}
	}

	void OnCollisionEnter2D(Collision2D obj){
		if (obj.gameObject.tag == "Spit") {
			enemyHealth --;

		}
	}
}
