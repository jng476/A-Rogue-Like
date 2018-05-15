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
	//open instructions
	public void Instructions(){
		mainMenu.SetActive (false);
		instructionsMenu.SetActive (true);
	}
	//close instructions
	public void Back(){
		instructionsMenu.SetActive (false);
		mainMenu.SetActive (true);

	}
	//open credits
	public void Credits(){
		SceneManager.LoadScene ("Credits");
	}
	//open main menu
	public void MainMenu(){
		SceneManager.LoadScene ("MainMenu");
	}
}
