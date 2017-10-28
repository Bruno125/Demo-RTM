using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupEnterRoom : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnDisable()
    {
        GetComponentInChildren<InputField>().text = "";
        //GetComponentInChildren<Image>().
    }
}
