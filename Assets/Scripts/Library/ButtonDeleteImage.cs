using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ButtonDeleteImage : MonoBehaviour, IPointerClickHandler
{

    public void OnPointerClick(PointerEventData eventData)
    {
        if (MainManager.Instance.auxImageSelection == -1) return;

        MainManager.Instance.DeleteImageFromLibrary(MainManager.Instance.auxImageSelection);

    }


}

