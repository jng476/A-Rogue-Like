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
		//go back to main menu when finished
		yield return new WaitForSeconds (30);
		SceneManager.LoadScene ("MainMenu");

	}
}
