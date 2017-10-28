using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ButtonAddToLibrary : MonoBehaviour, IPointerClickHandler
{

    public void OnPointerClick(PointerEventData eventData)
    {
        if (MainManager.Instance.auxImageSelection == -1) return;

        int imageId = MainManager.Instance.GetDevicePhotoID(MainManager.Instance.auxImageSelection);

        MainManager.Instance.AddImageToLibrary(imageId);

    }


}

