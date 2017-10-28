using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ButtonSaveSharedImage : MonoBehaviour, IPointerClickHandler
{

    public ShareView sharedView;

    public void OnPointerClick(PointerEventData eventData)
    {
        MainManager.Instance.AddImageToLibrary(sharedView.imageId);
    }


}

