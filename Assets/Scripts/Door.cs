using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

	public float transformx;
	public float transformy;
	public float transcamx;
	public float transcamy;
	bool can_Open = true;
	void OnTriggerEnter2D(Collider2D other) 
	{
		float x = other.gameObject.transform.position.x;
		float y = other.gameObject.transform.position.y;
		float camx = Camera.main.transform.position.x;
		float camy = Camera.main.transform.position.y;

		Debug.Log (other.tag);
		if (!can_Open)
			return;
		
		if (can_Open == true && other.CompareTag ("Player")) {
			can_Open = false;
			Door_Delay ();
			other.gameObject.transform.position = new Vector3 (x + transformx, y + transformy, 0);
			Camera.main.transform.position = new Vector3 (camx + transcamx, camy + transcamy, -2);
			can_Open = true;
		}

	}
	IEnumerator Door_Delay() {
		yield return new WaitForSeconds(0.5f);
	}
}
