using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Credits : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine(Finished ());
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			SceneManager.LoadScene ("MainMenu");
		}
	}

	IEnumerator Finished(){

		yield return new WaitForSeconds (20);
		SceneManager.LoadScene ("MainMenu");

	}
}
