using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
public class ButtonShareGestureSingle : MonoBehaviour,IPointerClickHandler
{

    public GameObject panelSharedView;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (MainManager.Instance.auxImageSelection == -1) return;

        var imageId = MainManager.Instance.GetLibraryPhotoID(MainManager.Instance.auxImageSelection);
        MultiplayerController.Instance.ShareGestureImageToSingle(imageId,MainManager.Instance.gestureTarget);
        MainManager.Instance.sharedImageID = imageId;

        panelSharedView.SetActive(true);
    }

}
