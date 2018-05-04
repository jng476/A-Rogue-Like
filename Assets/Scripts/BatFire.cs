using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatFire : MonoBehaviour {

	public GameObject bullet; // Gets Projectile.
	Transform rightPos, leftPos, upPos, downPos; //Gets where the position of where the projectile will fire.
	public float fireGap ; //Delay between firing.
	private float timestamp; //A timestamp for the delay.
	GameObject player;
	float xSpeed;
	float ySpeed;
	Vector3 room = new Vector3 (0, 0, 0); //Which Room the Enemy Belongs to.
	Vector3 spawn = new Vector3 (2, 0, 0); //Where the Enemy Initially Spawned.
	//initialization
	void Start () {
		rightPos = transform.Find ("BulletRight"); //Finds Transforms.
		leftPos = transform.Find ("BulletLeft");
		upPos = transform.Find ("BulletUp");
		downPos = transform.Find ("BulletDown");
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
			int direction = 0; 
			if (xSpeed > ySpeed && xSpeed > 0) {
				direction = 1;
			} else if (ySpeed > xSpeed && ySpeed > 0) {
				direction = 2;
			} else if (xSpeed < ySpeed && xSpeed < 0) {
				direction = 3;
			} else if (ySpeed < xSpeed && ySpeed < 0) {
				direction = 4;
			}

			//If Right Arrow is pressed Fire right and the delay has passed.
			if (Time.time >= timestamp && direction == 1) {
				Fire (rightPos);
			}
			//If Left Arrow is pressed Fire left and the delay has passed.
			if (Time.time >= timestamp && direction == 2) {
				Fire (leftPos);
			}
			//If up Arrow is pressed Fire up and the delay has passed.
			if (Time.time >= timestamp && direction == 3) {
				Fire (upPos);
			}
			//If down Arrow is pressed Fire down and the delay has passed.
			if (Time.time >= timestamp && direction == 4) {
				Fire (downPos);
			}
	}
	//Fires the bullet
	void Fire(Transform pos){

		GameObject newBullet = Instantiate(bullet, pos.position, Quaternion.identity);
		spitControl script = newBullet.GetComponent<spitControl> ();
		script.speed = new Vector2 (xSpeed, ySpeed);
		timestamp = Time.time + fireGap; //create delay.
		Debug.Log("Time Stamp: " + timestamp);
		Debug.Log ("Time: " + Time.time);
	}
}
