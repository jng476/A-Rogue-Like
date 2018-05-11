using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreSpit : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Physics2D.IgnoreLayerCollision(8, 8);
	}

	void Update(){
		
	}

}
