using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ReceiveGestureImageControl : MonoBehaviour {

    // Use this for initialization
    public RectTransform recTrans;
    public Button guardaImagenbtn;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        recTrans.transform.localPosition = new Vector3(recTrans.transform.localPosition.x,
               MainManager.Instance.posYGestureReceived - 380, recTrans.transform.localPosition.z);
        if (recTrans.transform.localPosition.y > 0)
        {
            recTrans.transform.localPosition = new Vector3(recTrans.transform.localPosition.x,
                   0, recTrans.transform.localPosition.z);
            guardaImagenbtn.enabled = true;
        }

        if(recTrans.transform.localPosition.y < -20)
        {
            guardaImagenbtn.enabled = false;
        }

        /*if (recTrans.transform.localPosition.y > 0)
            recTrans.transform.localPosition = new Vector3(recTrans.transform.localPosition.x,
                0, recTrans.transform.localPosition.z);*/
    }

    void OnEnable()
    {
        guardaImagenbtn.enabled = false;
    }
}
