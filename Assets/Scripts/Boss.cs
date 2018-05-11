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

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		boss = GetComponent<Rigidbody2D>();
		StartCoroutine(Tactics ());
	}
	
	// Update is called once per frame
	void Update () {
		if (goAgain == true && boss.transform.position.x != 0 && boss.transform.position.y !=0) {
			boss.transform.position = Vector2.MoveTowards (new Vector2 (boss.transform.position.x, boss.transform.position.y), new Vector2 (0, 0), 3 * Time.deltaTime);
		}
		else if (goAgain == true && boss.transform.position.x == 0 && boss.transform.position.y == 0) { 
			boss.transform.position = Vector2.MoveTowards (new Vector2(boss.transform.position.x, boss.transform.position.y), new Vector2 (0, 0), 3 * Time.deltaTime);
			if (phase == 2) {
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
			Charge ();
		}
		yield return new WaitForSeconds (3);
		goAgain = true;
		phase = 2;
	}

	//Charges players location 
	void Charge(){

		float xSpeed = (player.transform.position.x - this.transform.position.x);
		float ySpeed = (player.transform.position.y - this.transform.position.y);
		float legolas = Mathf.Sqrt (xSpeed * xSpeed + ySpeed * ySpeed); //legolas saved the day. 
		boss.velocity = new Vector2(xSpeed/legolas*speed, ySpeed/legolas*speed);
	}

	//Spits eruptions to kill player
	IEnumerator Volcanic(){
		phase = 3;
		//float x = 1;
		//float y = 0;
		//change this shit refractor my doggie
		for(int i = 0; i<4; i++){
		StartCoroutine (Spiral(new Vector2(1, 0), -0.1f, -0.1f));
		StartCoroutine (Spiral(new Vector2(0, -1f), -0.1f, 0.1f));
		StartCoroutine (Spiral(new Vector2(-1f, 0), 0.1f, 0.1f));
		StartCoroutine (Spiral(new Vector2(0, 1f), 0.1f, -0.1f));
		yield return new WaitForSeconds (6);
		}
		phase = 1;
	}

	IEnumerator Spiral(Vector2 pos, float changeX, float changeY){
		for (int i = 0; i < 10; i++) {
			Shoot (pos, pos.x*1.5f, pos.y*1.5f);
			pos.x += changeX;
			pos.y += changeY;
			yield return new WaitForSeconds (0.5f);
		}
	}

	void Shoot(Vector2 pos, float x, float y){
		GameObject newBullet = Instantiate (bossBullet, pos, Quaternion.identity);
		spitControl script = newBullet.GetComponent<spitControl> ();
		script.speed = new Vector2 (x*speed, y*speed);
	}
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Wall" || col.gameObject.tag == "Player") {
			boss.velocity = new Vector2 (0, 0);
		}

	}

	void OnCollisionStay2D(Collision2D col){
		if ( col.gameObject.tag == "Player") {
			boss.velocity = new Vector2 (0, 0);
		}

	}

	void OnDestroy(){

		Instantiate (ladder, new Vector2 (0, 0), Quaternion.identity);
	}
}
