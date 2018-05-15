using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {
	GameObject player;
	public GameObject bossBullet;
	Rigidbody2D boss;
	bool goAgain = true;
	int phase = 1;
	float speed = 1.5f;
	public GameObject ladder;
	Animator anime;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		anime = GetComponent<Animator> ();
		boss = GetComponent<Rigidbody2D>();
		StartCoroutine(Tactics ());
	}
	
	// Update is called once per frame
	void Update () {
		//moves to the center ready for phase 2
		if (goAgain == true && boss.transform.position.x != 0 && boss.transform.position.y !=0) {
			boss.transform.position = Vector2.MoveTowards (new Vector2 (boss.transform.position.x, boss.transform.position.y), new Vector2 (0, 0), 3 * Time.deltaTime);
		}
		//starts phase 2 then to phase 1
		else if (goAgain == true && boss.transform.position.x == 0 && boss.transform.position.y == 0) { 
			boss.transform.position = Vector2.MoveTowards (new Vector2(boss.transform.position.x, boss.transform.position.y), new Vector2 (0, 0), 3 * Time.deltaTime);
			if (phase == 2) {
				anime.SetInteger ("phase", 2);
				StartCoroutine (Volcanic ());
			}
			if (phase == 1) {
				speed++;
				StartCoroutine (Tactics ());
			}
		}
	}
	// Tactics for the boss
	IEnumerator  Tactics(){
		goAgain = false;
		phase = 3;
		for (int i = 0; i < 4; i++) {
			yield return new WaitForSeconds (3);
			anime.SetInteger ("phase", 1);
			Charge ();
		}
		yield return new WaitForSeconds (3);
		anime.SetInteger ("phase", 0);
		goAgain = true;
		phase = 2;
	}

	//Charges players location 
	void Charge(){

		float xSpeed = (player.transform.position.x - this.transform.position.x);
		float ySpeed = (player.transform.position.y - this.transform.position.y);
		float realspeed = Mathf.Sqrt (xSpeed * xSpeed + ySpeed * ySpeed); 
		boss.velocity = new Vector2(xSpeed/realspeed*speed, ySpeed/realspeed*speed);
	}

	//Spits eruptions to kill player
	IEnumerator Volcanic(){
		phase = 3;
		for(int i = 0; i<4; i++){
		StartCoroutine (Spiral(new Vector2(1, 0), -0.1f, -0.1f));//Fires Right spiral
		StartCoroutine (Spiral(new Vector2(0, -1f), -0.1f, 0.1f));//Fire Downwards Spiral
		StartCoroutine (Spiral(new Vector2(-1f, 0), 0.1f, 0.1f));//Fires Left Spiral
		StartCoroutine (Spiral(new Vector2(0, 1f), 0.1f, -0.1f));//Fires Upwards Spiral
		yield return new WaitForSeconds (6);
		}
		anime.SetInteger ("phase", 0);
		phase = 1;
	}

	//Shoots a Spiral of bullets
	IEnumerator Spiral(Vector2 pos, float changeX, float changeY){
		for (int i = 0; i < 10; i++) {
			Shoot (pos, pos.x*1.5f, pos.y*1.5f);
			pos.x += changeX;
			pos.y += changeY;
			yield return new WaitForSeconds (0.5f);
		}
	}

	//Shoots the bullet and sets a speed
	void Shoot(Vector2 pos, float x, float y){
		GameObject newBullet = Instantiate (bossBullet, pos, Quaternion.identity);
		spitControl script = newBullet.GetComponent<spitControl> ();
		script.speed = new Vector2 (x*speed, y*speed);
	}
	//If the boss hits the player or a wall stop.
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Wall" || col.gameObject.tag == "Player") {
			boss.velocity = new Vector2 (0, 0);
		}

	}
	//Stops if the player is still touching.
	void OnCollisionStay2D(Collision2D col){
		if (col.gameObject.tag == "Player") {
			boss.velocity = new Vector2 (0, 0);
		}

	}
	//When the boss is destroyed
	void OnDestroy(){
		EnemyStats script = this.GetComponent<EnemyStats> ();
		//If the boss is at 0 health it will spawn the ladders
		if (script.enemyHealth == 0) {
			Instantiate (ladder, new Vector2 (0, 0), Quaternion.identity);
		}
	}
}
