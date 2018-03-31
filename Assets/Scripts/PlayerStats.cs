using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {
	public int playerHealth = 0; //Players health
	Text health; //Health UI. 

	void Start () {
		playerHealth = 3; //Sets players health to 3
		health = FindObjectOfType<Text> (); //Gets health ui
	}

	void OnCollisionEnter2D(Collision2D obj){
		//checks if the player touches Enemy.
		if (obj.gameObject.tag == "Enemy") { 
			playerHealth = playerHealth - 1; //take damage
			health.text = "Health:" + playerHealth.ToString(); //change the health ui.
			if (playerHealth == 0) {
				SceneManager.LoadScene ("GameOver"); //GAME OVER

			}
		}
	}

	public int CurrentHealth(){
		
		return playerHealth;
	}
}
