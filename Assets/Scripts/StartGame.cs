using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {
	public GameObject room; //Room Prefab
	public GameObject rightDoor; //Prefab of Doors
	public GameObject leftDoor;
	public GameObject upDoor;
	public GameObject downDoor;
	public GameObject Player; //Player Prefab
	public GameObject Ladder; //Ladders for next level 
	public GameObject Enemy;//Enemy Prefab
	int room_Counter = 0; //Counter to keep count of rooms.
	int num_Of_Rooms; //How many Rooms in the level.
	Vector3[] roomPos; //Keeps the Position Of every Room.
	int level = 0;

	// Starts the Game
	void Start () {
		Instantiate (room, new Vector3 (0f, 0f, 0f), Quaternion.identity);
		Instantiate(Player, new Vector3(0f, 0f, 0f), Quaternion.identity); //Spawns the Player.
		level = 1;
		Create_Level(); 
	}
	//Creates the level.
	void Create_Level(){
		num_Of_Rooms = Random.Range (4, 12); //Picks a random number of rooms to create.
		roomPos = new Vector3[num_Of_Rooms]; //Makes Array of room positions of how many rooms being created.
		Vector3 pos = new Vector3(0f, 0f, 1f); //sets first rooms position.
		room_Counter = 0; //Sets counter to 0.
		Create_Room (pos, 2, 0); //Creates room with initial Position.
		Create_Ladder (); //Spawns ladder in Random Room.
		CreateEnemies (); //Creates Enemies in rooms.
	}
	//Creates Rooms.
	void Create_Room(Vector3 pos, int min, int preDir){
		//If number of rooms remaining is greater than 4 must create 2 more rooms.
		if (num_Of_Rooms > 4) {
			min = 2;
		}
		int num_Of_Doors = Random.Range (min, 4 % num_Of_Rooms); //Gets a random number of rooms to create.
		num_Of_Rooms = num_Of_Rooms - num_Of_Doors; //Decrease the amount of rooms needed to create.
		Instantiate (room, pos, Quaternion.identity); //Create a room.
		roomPos [room_Counter] = pos; //Sets the position of the Created Room.
		room_Counter++; //Increase the counter of the room.
		int[] currentdoors = new int[num_Of_Doors+1]; //Creates a array of the doors in the room.
		currentdoors[0] = preDir;
		int counter = 1; //Sets a ccounter for the doors.
		int dir; //Create variable for the direction where the door will be. 
		bool dirTaken; //boolean to check if the direction has been taken.
		//For loop to create door.
		for (int i = 0; i < num_Of_Doors; i++) {
			Debug.Log ("This is stil the preDir " + currentdoors [0]);
			do {
				dirTaken = false; //Sets taken direction to false.
				dir = Random.Range (1, 4); //Picks a random Direction.
				//Checks if direction has been taken.
				for (int j = 0; j < currentdoors.Length; j++) {
					if (dir == currentdoors[j]) {
						Debug.Log("This Direction has been taken" + dir);
						dirTaken = true;
					}
				}
			} while(dirTaken != false); //If directions taken do again and pick another.
			Debug.Log("This the direction we have taken" + dir);
			currentdoors[counter] = dir; //Sets Door Direction.
			counter++; 
			Create_Door (dir, pos); //Creates door.
		}

	}

	void Create_Door(int direction, Vector3 pos){
		//If Direction Is Right.
		if (direction == 1) {
			Instantiate (rightDoor, new Vector3 (pos.x + 3.44f, pos.y, pos.z - 1), Quaternion.identity); //Create a door on the Right.
			Instantiate (leftDoor, new Vector3 (pos.x + 4.55f, pos.y, pos.z - 1), Quaternion.identity); //Create door on the left of the next room.
			Create_Room (new Vector3(pos.x + 8f, pos.y, pos.z), 0, 2); //Create a room to the Right.
		}
		else if (direction == 2) {
			Instantiate (leftDoor, new Vector3 (pos.x - 3.44f, pos.y, pos.z - 1), Quaternion.identity);//Create a door on the Left.
			Instantiate (rightDoor, new Vector3 (pos.x - 4.55f, pos.y, pos.z - 1), Quaternion.identity); //Create door on the right of the next room.
			Create_Room (new Vector3(pos.x - 8f, pos.y, pos.z), 0, 1);//Create a room to the Left.
		}
		else if (direction == 3) {
			Instantiate (upDoor, new Vector3 (pos.x, pos.y + 1.96f, pos.z - 1), Quaternion.Euler(0,0,90));//Create a door on the top.
			Instantiate (downDoor, new Vector3 (pos.x, pos.y + 2.73f, pos.z - 1), Quaternion.Euler(0,0,90)); //Create door on the bottom of the next room.
			Create_Room (new Vector3(pos.x , pos.y + 4.55f, pos.z), 0, 4);//Create a room upwards.
		}
		else if (direction == 4) {
			Instantiate (downDoor, new Vector3 (pos.x, pos.y - 1.96f, pos.z - 1f), Quaternion.Euler(0,0,-90));//Create a door on the bottom.
			Instantiate (upDoor, new Vector3 (pos.x, pos.y - 2.73f, pos.z - 1), Quaternion.Euler(0,0,90)); //Create door on the top of the next room.
			Create_Room (new Vector3(pos.x, pos.y - 4.55f, pos.z), 0, 3);//Create a room at the bottom.
		}
	}
	//Creates new level.
	public void next_Level(){
		Debug.Log ("Destroying Doors"); //Destroys all objects.
		destroy_Objects ("Door");
		Debug.Log ("Destroyed Doors");
		destroy_Objects ("Room");
		Debug.Log ("Starting new level");
		destroy_Objects ("Ladder");
		Debug.Log("Destroying Ladders");
		destroy_Objects ("Enemy");
		level++;
		if (level == 3) {
			SceneManager.LoadScene ("Winning");
		}
		Create_Level(); //Creates new level.
		GameObject player = GameObject.FindGameObjectWithTag ("Player"); //Sets player to starting position.
		player.transform.position = new Vector3 (0f, 0f, 0f);
		Camera.main.transform.position = new Vector3 (0f, 0f, -2f); //Sets Camera to starting position.
	}

	//Destorys Objects with certain tag.
	void destroy_Objects(string tag){
		GameObject[] objects;
		objects = GameObject.FindGameObjectsWithTag (tag);

		foreach (GameObject o in objects) {
			Destroy (o.gameObject);
		}
	}
	//Spawns ladder in certain room.
	void Create_Ladder(){

		bool ladder_Space = false;
		int space = 0;
		while (ladder_Space != true) {

			space = Random.Range (1, roomPos.Length - 1);

			if (roomPos [space] != new Vector3(0, 0, 1)) {

				ladder_Space = true;
			}

		}
		Debug.Log (roomPos[space]);
		Instantiate (Ladder, new Vector3 (roomPos [space].x + 1f, roomPos [space].y, roomPos [space].z +1), Quaternion.identity);

	}
	//Create enemies
	void CreateEnemies(){
		for (int num = 1; num < roomPos.Length - 1; num++) {
			Debug.Log("First Room " + roomPos [1].x);
			int amountOfEnemies = Random.Range (1, 4);
			for (int i = 1; i < amountOfEnemies; i++) {
				float randomX = Random.Range (roomPos [num].x - 2, roomPos [num].x + 2);
				float randomy = Random.Range (roomPos [num].y - 2, roomPos [num].y + 2);
				GameObject newEnemy = Instantiate(Enemy, new Vector3(randomX, randomy, 0), Quaternion.identity);
				EnemyMovement script = newEnemy.GetComponent<EnemyMovement>();
				script.SetRoom (new Vector3(roomPos [num].x, roomPos [num].y, roomPos [num].z));
				script.SetSpawn (new Vector3(randomX, randomy, 0));
			}
		}
	}
}
