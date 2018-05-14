using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatFire : MonoBehaviour {

	public GameObject bullet; // Gets Projectile.
	public float fireGap ; //Delay between firing.
	private float timestamp; //A timestamp for the delay.
	GameObject player;
	float xSpeed;
	float ySpeed;
	Vector3 room = new Vector3 (0, 0, 0); //Which Room the Enemy Belongs to.
	Vector3 spawn = new Vector3 (2, 0, 0); //Where the Enemy Initially Spawned.
	//initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void Update () {
		player = GameObject.FindGameObjectWithTag ("Player");
		if (inRoom () == true) {
			FireLocation();
		} 
	}

	bool inRoom(){
		if (player.transform.position.x < room.x + 3.5 && player.transform.position.x > room.x - 3.5 && player.transform.position.y < room.y + 1.85 && player.transform.position.y > room.y - 1.85) {
			return true;
		} else {
			return false;
		}

	}

	void FireLocation() {
			xSpeed = (player.transform.position.x - this.transform.position.x) / 2;
			ySpeed = (player.transform.position.y - this.transform.position.y) / 2;

			//If Right Arrow is pressed Fire right and the delay has passed.
			if (Time.time >= timestamp ) {
				Fire ();
			}
			
	}
	//Fires the bullet
	void Fire(){
		GameObject newBullet = Instantiate(bullet, new Vector2 (this.gameObject.transform.position.x, this.gameObject.transform.position.y), Quaternion.identity);
		spitControl script = newBullet.GetComponent<spitControl> ();
		script.speed = new Vector2 (xSpeed, ySpeed);
		timestamp = Time.time + fireGap; //create delay.
		Debug.Log("Time Stamp: " + timestamp);
		Debug.Log ("Time: " + Time.time);
	}

	public void SetRoom(Vector3 spawnRoom){
		room = spawnRoom;

	}
}
