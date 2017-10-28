using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ButtonDevice : MonoBehaviour, IPointerClickHandler
{
    public GameObject PanelDevice;

    public void OnPointerClick(PointerEventData eventData)
    {
        PanelDevice.SetActive(true);
    }


}
