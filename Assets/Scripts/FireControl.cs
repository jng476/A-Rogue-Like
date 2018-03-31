using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireControl : MonoBehaviour {

	public GameObject spitRight, spitLeft, spitUp, spitDown; // Gets Projectile.
	Transform spitRightPos, spitLeftPos, spitUpPos, spitDownPos; //Gets where the position of where the projectile will fire.
	public float fireGap = 0.5f; //Delay between firing.
	float rotation = 0; //how much to rotate the projectile.
	private float timestamp; //A timestamp for the delay.

	//initialization
	void Start () {
	spitRightPos = transform.Find ("spitRight"); //Finds Transforms.
	spitLeftPos = transform.Find ("spitLeft");
	spitUpPos = transform.Find ("spitUp");
	spitDownPos = transform.Find ("spitDown");

	}

	void Update () {
		//If Right Arrow is pressed Fire right and the delay has passed.
		if (Time.time >= timestamp && (Input.GetKeyDown (KeyCode.RightArrow))) {
			rotation = 0;
			Fire(spitRight, spitRightPos);
		}
		//If Left Arrow is pressed Fire left and the delay has passed.
		if (Time.time >= timestamp && (Input.GetKeyDown (KeyCode.LeftArrow))) {
			rotation = 0;
			Fire(spitLeft, spitLeftPos);
		}
		//If up Arrow is pressed Fire up and the delay has passed.
		if (Time.time >= timestamp && (Input.GetKeyDown (KeyCode.UpArrow))) {
			rotation = 90; //Sets bullets rotation.
			Fire(spitUp, spitUpPos);
		}
		//If down Arrow is pressed Fire down and the delay has passed.
		if (Time.time >= timestamp && (Input.GetKeyDown (KeyCode.DownArrow))) {
			rotation = -90; 
			Fire(spitDown, spitDownPos);
		}
	}
	//Fires the bullet
	void Fire(GameObject spitDirection, Transform spitPosition){

		Instantiate (spitDirection, spitPosition.position, Quaternion.Euler(0,0,rotation));
		timestamp = Time.time + fireGap; //create delay.

	}
}
