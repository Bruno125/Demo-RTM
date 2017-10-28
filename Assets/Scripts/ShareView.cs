using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShareView : MonoBehaviour {

    public Image sharedImage;
    public int imageId;
	// Use this for initialization
	void Start () {
		
	}
	
	void OnEnable()
    {
        imageId = MainManager.Instance.sharedImageID;
        sharedImage.sprite = (Sprite)Resources.Load(imageId.ToString(), typeof(Sprite));
        int myPart =MainManager.Instance.sharedImagePart;
        int players = MultiplayerController.Instance.GetAllPlayers().Count;
        int ancho = sharedImage.sprite.texture.width / players;
        sharedImage.sprite = Sprite.Create(sharedImage.sprite.texture, new Rect(myPart * ancho, 0, ancho, sharedImage.sprite.texture.height), new Vector2(0.5f, 0.5f));

    }
}
