using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShareViewGesture : MonoBehaviour
{

    public Image sharedImage;
    public int imageId;
    // Use this for initialization
    void Start()
    {

    }
    void OnEnable()
    {
        imageId = MainManager.Instance.sharedImageID;
        sharedImage.sprite = (Sprite)Resources.Load(imageId.ToString(), typeof(Sprite));
    }
}
