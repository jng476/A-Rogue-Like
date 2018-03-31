using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
	
	public float speed; //Players MovementSpeed.
	private Rigidbody2D player; //The player
	Animator anime; //Players Animation.
	void Start(){

		player = GetComponent<Rigidbody2D> (); //Gets player component.
		anime = GetComponent<Animator> (); //Gets players animation components.

	}

	void FixedUpdate(){
		
		float moveHorizontal = Input.GetAxis ("Horizontal"); //checks if the players moving up.
		float moveVertical = Input.GetAxis ("Vertical"); //checks if player is moving down.
		anime.SetFloat ("xValue", moveHorizontal); //Sets value is player is move in the x axis.
		anime.SetFloat ("yValue", moveVertical); //Sets value is player is move in the y axis.
		//checks if the player wants to move.
		if (moveHorizontal != 0 || moveVertical != 0) {
			Vector2 movement = new Vector2 (Mathf.Round(moveHorizontal), Mathf.Round(moveVertical));
			player.velocity = new Vector2(moveHorizontal*speed, moveVertical*speed); //moves player
		} else {
			//if no input has been pressed stay still.
			player.velocity = new Vector2 (0, 0);
		}
			
	}
		
}
