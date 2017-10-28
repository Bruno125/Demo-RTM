using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRoom : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        MultiplayerController.Instance.SignInAndStartMPGame();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
