using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ButtonSearchImageEnterRoom : MonoBehaviour, IPointerClickHandler
{
    public GameObject PanelDevice;

    public void OnPointerClick(PointerEventData eventData)
    {
        MainManager.Instance.auxImageSelection = -1;
        PanelDevice.SetActive(true);
    }


}
