using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {
	public int playerHealth = 0;
	Text health; 
	// Use this for initialization
	void Start () {
		playerHealth = 3;
		health = FindObjectOfType<Text> ();
	}

	void OnCollisionEnter2D(Collision2D obj){
		if (obj.gameObject.tag == "Enemy") {
			playerHealth = playerHealth - 1;
			health.text = "Health:" + playerHealth.ToString();
			if (playerHealth == 0) {
				SceneManager.LoadScene ("GameOver");

			}
		}
	}

	public int CurrentHealth(){
		
		return playerHealth;
	}
}
