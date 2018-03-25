using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour {
	// Use this for initialization
	public GameObject room;
	public GameObject rightDoor;
	public GameObject leftDoor;
	public GameObject upDoor;
	public GameObject downDoor;
	public GameObject Player;
	public GameObject Ladder;
	int num_Of_Rooms;
	Vector3[] roomPos;
	void OnTriggerEnter2D(Collider2D other)
	{
		
		StartGame game = new StartGame();
		if ( other.CompareTag ("Player")) {
			Camera.main.GetComponent<StartGame>().next_Level();

		}
	}

	void destroy_Objects(string tag){
		GameObject[] objects;
		objects = GameObject.FindGameObjectsWithTag (tag);

		foreach (GameObject o in objects) {
			Destroy (o.gameObject);
			Debug.Log ("Destroyed Object");

		}
	}
}
