using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {
	Rigidbody2D player; 
	public int playerHealth = 0; //Players health
	Text health; //Health UI. 
	//Initialise
	void Start () {
		playerHealth = 3; //Sets players health to 3
		health = FindObjectOfType<Text> (); //Gets health ui
		player = GetComponent<Rigidbody2D>();
	}

	//If player hits an object
	void OnCollisionEnter2D(Collision2D obj){
		//checks if the player touches Enemy.
		if (obj.gameObject.tag == "Enemy" || obj.gameObject.tag == "Spit" || obj.gameObject.tag == "bossBullet") { 
			StartCoroutine (knockBack ());
			playerHealth = playerHealth - 1; //take damage
			health.text = "Health:" + playerHealth.ToString(); //change the health ui.
			if (playerHealth == 0) {
				SceneManager.LoadScene ("GameOver"); //GAME OVER

			}
		}
	}

	//Get players Current Health
	public int CurrentHealth(){
		
		return playerHealth;
	}
	//Knock Back player
	IEnumerator knockBack(){
		player.velocity = new Vector2 (-2.5f, 0);
		yield return new WaitForSeconds (0.5f);
		player.velocity = new Vector2 (0, 0);
	}
}
