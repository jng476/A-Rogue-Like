using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireControl : MonoBehaviour {

	public GameObject spitRight, spitLeft, spitUp, spitDown;
	Transform spitRightPos, spitLeftPos, spitUpPos, spitDownPos;
	public float fireGap = 0.5f;
	float rotation = 0;
	private float timestamp;
	// Use this for initialization
	void Start () {
	spitRightPos = transform.Find ("spitRight");
	spitLeftPos = transform.Find ("spitLeft");
	spitUpPos = transform.Find ("spitUp");
	spitDownPos = transform.Find ("spitDown");
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time >= timestamp && (Input.GetKeyDown (KeyCode.RightArrow))) {
			rotation = 0;
			Fire(spitRight, spitRightPos);
		}
		if (Time.time >= timestamp && (Input.GetKeyDown (KeyCode.LeftArrow))) {
			rotation = 0;
			Fire(spitLeft, spitLeftPos);
		}
		if (Time.time >= timestamp && (Input.GetKeyDown (KeyCode.UpArrow))) {
			rotation = 90;
			Fire(spitUp, spitUpPos);
		}
		if (Time.time >= timestamp && (Input.GetKeyDown (KeyCode.DownArrow))) {
			rotation = -90;
			Fire(spitDown, spitDownPos);
		}
	}

	void Fire(GameObject spitDirection, Transform spitPosition){

		Instantiate (spitDirection, spitPosition.position, Quaternion.Euler(0,0,rotation));
		timestamp = Time.time + fireGap;

	}
}
