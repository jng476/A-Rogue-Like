using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

	public float transformx; //How far will the player transport in the x axis
	public float transformy; //How far will the player transport in the y axis
	public float transcamx; //How far will the camera transport in the x axis
	public float transcamy; //How far will the camera transport in the y axis

	bool can_Open = true; 

	// When Object Collides
	void OnTriggerEnter2D(Collider2D other) 
	{
		if (!can_Open) //If you can't open door cancel.
			return;

		//checks if the player touches door
		if (can_Open == true && other.CompareTag ("Player")) {
			float x = other.gameObject.transform.position.x; //Gets Players x position
			float y = other.gameObject.transform.position.y; //Gets Players y Position
			float camx = Camera.main.transform.position.x; //Gets Camera's x position
			float camy = Camera.main.transform.position.y; //Gets Camera's y position
			can_Open = false; // Lock the Door
			other.gameObject.transform.position = new Vector3 (x + transformx, y + transformy, 0); //Transport player to next room
			Camera.main.transform.position = new Vector3 (camx + transcamx, camy + transcamy, -2); //Move Camera to next room.
			can_Open = true; //Unlock the door
		}

	}
}
