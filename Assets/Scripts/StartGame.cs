using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour {
	public GameObject room;
	public GameObject rightDoor;
	public GameObject leftDoor;
	public GameObject upDoor;
	public GameObject downDoor;
	public GameObject Player;
	public GameObject Ladder;
	public GameObject Enemy;
	int room_Counter = 0;
	int num_Of_Rooms;
	Vector3[] roomPos;
	// Use this for initialization
	void Start () {
		//Vector3 pos = new Vector3(0f, 0f, 1f);
		//Instantiate (room, pos, Quaternion.identity);
		//pos = new Vector3(0f, 4.51f,1f);
		//Instantiate (room, pos, Quaternion.identity);
		//pos = new Vector3 (0f, 1.96f, 0f);
		//Instantiate (upDoor, pos, Quaternion.Euler(0,0,90));
		//pos = new Vector3 (0f, 2.73f, 0f);
		//Instantiate (downDoor, pos, Quaternion.Euler(0,0,-90));
		//downDoor.transform.Rotate(0, 0, 270);
		//Debug.Log (Random.Range(4,8));
		Instantiate(Player, new Vector3(0f, 0f, 0f), Quaternion.identity);
		Create_Level();
	}

	void Create_Level(){
		num_Of_Rooms = Random.Range (4, 12);
		roomPos = new Vector3[num_Of_Rooms];
		Vector3 pos = new Vector3(0f, 0f, 1f);
		room_Counter = 0;
		Create_Room (pos, 2);
		Create_Ladder ();
		CreateEnemies ();
	}
	void Create_Room(Vector3 pos, int min){
		if (num_Of_Rooms > 4) {
			min = 2;
		}
		int num_Of_Doors = Random.Range (min, 4 % num_Of_Rooms);
		num_Of_Rooms = num_Of_Rooms - num_Of_Doors;
		Debug.Log (num_Of_Rooms);
		Instantiate (room, pos, Quaternion.identity);
		roomPos [room_Counter] = pos;
		Debug.Log(roomPos[0]);
		room_Counter++;
		int[] currentdoors = new int[4];
		int counter = 0;
		int dir;
		bool dirTaken;
		for (int i = 0; i < num_Of_Doors; i++) {
			do {
				dirTaken = false;
				dir = Random.Range (1, 4);
				for (int j = 0; j < currentdoors.Length; j++) {
					if (dir == currentdoors[j]) {
						dirTaken = true;
					}
				}
			} while(dirTaken != false);
			currentdoors[counter] = dir;
			counter++;
			Create_Door (dir, pos);
		}
		Debug.Log ("Room Finished");
	}

	void Create_Door(int direction, Vector3 pos){
		int min = 0;
		if (direction == 1) {
			Instantiate (rightDoor, new Vector3 (pos.x + 3.44f, pos.y, pos.z - 1), Quaternion.identity);
			Instantiate (leftDoor, new Vector3 (pos.x + 4.55f, pos.y, pos.z - 1), Quaternion.identity);
			Create_Room (new Vector3(pos.x + 8f, pos.y, pos.z), min);
		}
		else if (direction == 2) {
			Instantiate (leftDoor, new Vector3 (pos.x - 3.44f, pos.y, pos.z - 1), Quaternion.identity);
			Instantiate (rightDoor, new Vector3 (pos.x - 4.55f, pos.y, pos.z - 1), Quaternion.identity);
			Create_Room (new Vector3(pos.x - 8f, pos.y, pos.z), min);
		}
		else if (direction == 3) {
			Instantiate (upDoor, new Vector3 (pos.x, pos.y + 1.96f, pos.z - 1), Quaternion.Euler(0,0,90));
			Instantiate (downDoor, new Vector3 (pos.x, pos.y + 2.73f, pos.z - 1), Quaternion.Euler(0,0,90));
			Create_Room (new Vector3(pos.x , pos.y + 4.55f, pos.z), min);
		}
		else if (direction == 4) {
			Instantiate (downDoor, new Vector3 (pos.x, pos.y - 1.96f, pos.z - 1f), Quaternion.Euler(0,0,-90));
			Instantiate (upDoor, new Vector3 (pos.x, pos.y - 2.73f, pos.z - 1), Quaternion.Euler(0,0,90));
			Create_Room (new Vector3(pos.x, pos.y - 4.55f, pos.z), min);
		}
	}

	public void next_Level(){
		Debug.Log ("Destroying Doors");
		destroy_Objects ("Door");
		Debug.Log ("Destroyed Doors");
		destroy_Objects ("Room");
		Debug.Log ("Starting new level");
		destroy_Objects ("Ladder");
		Debug.Log("Destroying Ladders");
		destroy_Objects ("Enemy");
		Create_Level();
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		player.transform.position = new Vector3 (0f, 0f, 0f);
		Camera.main.transform.position = new Vector3 (0f, 0f, -2f);
	}

	void destroy_Objects(string tag){
		GameObject[] objects;
		objects = GameObject.FindGameObjectsWithTag (tag);

		foreach (GameObject o in objects) {
			Destroy (o.gameObject);
			Debug.Log ("Destroyed Object");

		}
	}

	void Create_Ladder(){

		bool ladder_Space = false;
		int space = 0;
		while (ladder_Space != true) {

			space = Random.Range (1, roomPos.Length - 1);
			Debug.Log (roomPos.Length);
			Debug.Log ("space is " + space);

			if (roomPos [space] != new Vector3(0, 0, 1)) {

				ladder_Space = true;
			}

		}
		Debug.Log (roomPos[space]);
		Instantiate (Ladder, new Vector3 (roomPos [space].x + 1f, roomPos [space].y, roomPos [space].z +1), Quaternion.identity);

	}

	void CreateEnemies(){
		for (int num = 1; num < roomPos.Length - 1; num++) {
			Debug.Log("First Room " + roomPos [1].x);
			int amountOfEnemies = Random.Range (1, 4);
			for (int i = 1; i < amountOfEnemies; i++) {
				float randomX = Random.Range (roomPos [num].x - 2, roomPos [num].x + 2);
				Debug.Log ("x" + randomX);
				float randomy = Random.Range (roomPos [num].y - 2, roomPos [num].y + 2);
				Debug.Log ("Y" + randomy);
				GameObject newEnemy = Instantiate(Enemy, new Vector3(randomX, randomy, 0), Quaternion.identity);
				EnemyMovement script = newEnemy.GetComponent<EnemyMovement>();
				script.SetRoom (new Vector3(roomPos [num].x, roomPos [num].y, roomPos [num].z));
				script.SetSpawn (new Vector3(randomX, randomy, 0));
			}
		}
	}
}
