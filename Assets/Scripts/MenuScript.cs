using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

	public void StartGame(){
		SceneManager.LoadScene ("Game");
	}
	
	// Update is called once per frame
	public void Exit () {
		Application.Quit ();
	}
}
