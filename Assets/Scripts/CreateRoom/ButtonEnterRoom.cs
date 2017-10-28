using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ButtonEnterRoom : MonoBehaviour, IPointerClickHandler
{
    public GameObject PanelEnterRoom;

    public void OnPointerClick(PointerEventData eventData)
    {

        PanelEnterRoom.SetActive(true);

    }

   
}
