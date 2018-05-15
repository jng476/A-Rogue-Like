using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public static bool paused = false;
	public GameObject pauseMenu;
	// Update is called once per frame


	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape)||Input.GetKeyDown(KeyCode.P))
		{
			if (paused) {
				Resume ();
			} else {
				Pause ();
			}

	}
}
	//Resume the game
	public void Resume(){

		pauseMenu.SetActive (false);
		Time.timeScale = 1f;
		paused = false;
	}

	//pauses game
	void Pause(){
		pauseMenu.SetActive (true);
		Time.timeScale = 0;
		paused = true;
	}

	//Goes to main menu
	public void Menu(){
		Time.timeScale = 1;
		SceneManager.LoadScene ("MainMenu");

	}
	//Quits Game
	public void Quit(){
		Application.Quit ();

	}
}