using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SharedImageControl : MonoBehaviour {

    // Use this for initialization

    public RectTransform recTrans;

	void Start ()
    {
        		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (recTrans.transform.localPosition.y > 380)
            Debug.Log("TRANSFERIDA PAPU");
        if (recTrans.transform.localPosition.y < 0)
            recTrans.transform.localPosition = new Vector3(recTrans.transform.localPosition.x,
                0, recTrans.transform.localPosition.z);
        MultiplayerController.Instance.SentGestureImageY(recTrans.transform.localPosition.y,"xD");
    }
    void OnEnable()
    {
        recTrans.transform.localPosition = new Vector3(recTrans.transform.localPosition.x,
                 0, recTrans.transform.localPosition.z);
    }
}
