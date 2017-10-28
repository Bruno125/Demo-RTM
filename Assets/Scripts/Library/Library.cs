using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Library : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	void OnEnable()
    {
        MainManager.Instance.DisplayLibrary();

        for (int i = 0; i < MainManager.Instance.libraryCount; i++)
        {
            MainManager.Instance.libraryImages[i].gameObject.transform.SetParent(this.gameObject.transform);
        }
    }
}
