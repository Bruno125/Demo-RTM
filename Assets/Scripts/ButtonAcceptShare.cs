using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ButtonAcceptShare : MonoBehaviour, IPointerClickHandler
{
    public GameObject panelSharedView;
    public GameObject sharedPopup;

    public void OnPointerClick(PointerEventData eventData)
    {
        panelSharedView.SetActive(true);
        sharedPopup.SetActive(false);

    }


}

