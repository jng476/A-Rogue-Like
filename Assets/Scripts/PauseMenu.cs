using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public static bool paused = false;
	public GameObject pauseMenu;
	// Update is called once per frame


	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			if (paused) {
				Resume ();
			} else {
				Pause ();
			}

	}
}

	public void Resume(){

		pauseMenu.SetActive (false);
		Time.timeScale = 1f;
		paused = false;
	}


	void Pause(){
		Debug.Log ("Ive Paused");
		pauseMenu.SetActive (true);
		Time.timeScale = 0;
		paused = true;
	}


	public void Menu(){
		Time.timeScale = 1;
		SceneManager.LoadScene ("MainMenu");


	}
	public void Quit(){
		Application.Quit ();

	}
}