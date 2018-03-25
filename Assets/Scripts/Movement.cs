using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
	public float speed;
	private Rigidbody2D player;
	public float num;
	Animator anime;
	void Start(){

		player = GetComponent<Rigidbody2D> ();
		anime = GetComponent<Animator> ();

	}

	void FixedUpdate(){
		
		float moveHorizontal = Input.GetAxis ("Horizontal");
		num = moveHorizontal;
		float moveVertical = Input.GetAxis ("Vertical");
		anime.SetFloat ("xValue", moveHorizontal);
		anime.SetFloat ("yValue", moveVertical);
		if (moveHorizontal != 0 || moveVertical != 0) {
			Vector2 movement = new Vector2 (Mathf.Round(moveHorizontal), Mathf.Round(moveVertical));
			player.velocity = new Vector2(moveHorizontal*speed, moveVertical*speed);
		} else {
			player.velocity = new Vector2 (0, 0);
		}
			
	}
		
}
