using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {
	public GameObject mainMenu;
	public GameObject instructionsMenu;
	public void StartGame(){
		SceneManager.LoadScene ("Game");
	}
	
	// Update is called once per frame
	public void Exit () {
		Application.Quit ();
	}

	public void Instructions(){
		mainMenu.SetActive (false);
		instructionsMenu.SetActive (true);
	}

	public void Back(){
		instructionsMenu.SetActive (false);
		mainMenu.SetActive (true);

	}

	public void Credits(){
		SceneManager.LoadScene ("Credits");
	}

	public void MainMenu(){
		SceneManager.LoadScene ("MainMenu");
	}
}
