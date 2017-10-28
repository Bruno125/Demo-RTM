using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ButtonShareToAll : MonoBehaviour, IPointerClickHandler
{
    public GameObject panelSharedView;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (MainManager.Instance.auxImageSelection == -1) return;

        MainManager.Instance.sharedImagePart = 0;
        var  imageId = MainManager.Instance.GetLibraryPhotoID(MainManager.Instance.auxImageSelection);
        MultiplayerController.Instance.ShareImageToAll(imageId);
        MainManager.Instance.sharedImageID = imageId;
       
        panelSharedView.SetActive(true);
    }


}

