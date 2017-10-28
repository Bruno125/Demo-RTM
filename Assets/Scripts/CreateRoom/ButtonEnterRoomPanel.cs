using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ButtonEnterRoomPanel : MonoBehaviour, IPointerClickHandler
{
    public GameObject PanelCreateRoom;
    public GameObject PanelRoom;
    public GameObject PopupEnterRoom;

    public void OnPointerClick(PointerEventData eventData)
    {
        PopupEnterRoom.SetActive(false);
        PanelCreateRoom.SetActive(false);
        PanelRoom.SetActive(true);
    }

  
}
