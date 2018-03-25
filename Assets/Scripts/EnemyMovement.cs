using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	private Rigidbody2D enemy;
	float speed = 0.4f;
	float moveHorizontal = 0;
	float moveVertical = 0;
	GameObject player;
	Vector3 room = new Vector3 (0, 0, 0);
	Vector3 spawn = new Vector3 (2, 0, 0);
	void Start(){
		enemy = GetComponent<Rigidbody2D> ();
	}
	// Update is called once per frame
	void Update () {
		player = GameObject.FindGameObjectWithTag ("Player");
		if (inRoom () == true) {
			Move ();
		} else {
			enemy.velocity = new Vector2 (0, 0);
			enemy.transform.position = spawn;
		}
	}
	bool inRoom(){
		if (player.transform.position.x < room.x + 3.5 && player.transform.position.x > room.x - 3.5 && player.transform.position.y < room.y + 1.85 && player.transform.position.y > room.y - 1.85) {
			return true;
		} else {
			return false;
		}

	}
	public void SetRoom(Vector3 setRoom){
		room = setRoom;
	}
	public void SetSpawn(Vector3 setSpawn){
		spawn = setSpawn;
	}
	void Move(){
		if (player.transform.position.x > enemy.transform.position.x) {
			moveHorizontal = 1;

		} else if (player.transform.position.x < enemy.transform.position.x) {
			moveHorizontal = -1;

		} else {

			moveHorizontal = 0;
		}
		if (player.transform.position.y > enemy.transform.position.y) {
			moveVertical = 1;

		} else if (player.transform.position.y < enemy.transform.position.y) {
			moveVertical = -1;

		} else {

			moveVertical = 0;
		}

		Vector2 movement = new Vector2 (Mathf.Round(moveHorizontal), Mathf.Round(moveVertical));
		enemy.velocity = new Vector2(moveHorizontal*speed, moveVertical*speed);

	}
}
