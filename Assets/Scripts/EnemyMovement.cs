using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	private Rigidbody2D enemy; //Get the Enemy
	public float speed = 0.4f; //Enemy's Movement Speed
	float moveHorizontal = 0; //Enemy Moves Horizontal
	float moveVertical = 0; //Enemy Moves Vertical
	GameObject player; //Find Player
	Vector3 room = new Vector3 (0, 0, 0); //Which Room the Enemy Belongs to.
	Vector3 spawn = new Vector3 (2, 0, 0); //Where the Enemy Initially Spawned.

	//Gets component of the Enemy
	void Start(){
		enemy = GetComponent<Rigidbody2D> ();
	}

	// Checks to see if the Player is in the same room else Stays at spawn location.
	void Update () {
		player = GameObject.FindGameObjectWithTag ("Player");
		if (inRoom () == true) {
			Move ();
		} else {
			enemy.velocity = new Vector2 (0, 0);
			enemy.transform.position = spawn;
		}

		if (player.transform.position.x > enemy.transform.position.x) {
			enemy.transform.localRotation = Quaternion.Euler (0, 180, 0);
		} else {
			enemy.transform.localRotation = Quaternion.Euler (0, 0, 0);
		}
	}

	//Checks if the Player is in the same room as the Enemy.
	bool inRoom(){
		if (player.transform.position.x < room.x + 3.5 && player.transform.position.x > room.x - 3.5 && player.transform.position.y < room.y + 1.85 && player.transform.position.y > room.y - 1.85) {
			return true;
		} else {
			return false;
		}

	}
	//Sets Enemy's Room
	public void SetRoom(Vector3 setRoom){
		room = setRoom;
	}
	//Set's Initial Spawn Location
	public void SetSpawn(Vector3 setSpawn){
		spawn = setSpawn;
	}
	//If the Player is in the Room Move to the player.
	void Move(){
		//If player is to the right of the enemy
		if (player.transform.position.x > enemy.transform.position.x) {
			moveHorizontal = 1;
			//If player is to the left of the enemy
		} else if (player.transform.position.x < enemy.transform.position.x) {
			moveHorizontal = -1;
			//If player is not to the left or right of the enemy.
		} else {

			moveHorizontal = 0;
		}
		//If player is above of the enemy
		if (player.transform.position.y > enemy.transform.position.y) {
			moveVertical = 1;
		//If player is under of the enemy
		} else if (player.transform.position.y < enemy.transform.position.y) {
			moveVertical = -1;
		//If player is not above or under the enemy
		} else {

			moveVertical = 0;
		}
		//Sets the movement speed and moves the enemy. 
		enemy.velocity = new Vector2(moveHorizontal*speed, moveVertical*speed);

	}
}
