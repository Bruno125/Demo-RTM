using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ButtonEnterRoomCancelPopup : MonoBehaviour, IPointerClickHandler
{
    public GameObject PopupEnterRoom;

    public void OnPointerClick(PointerEventData eventData)
    {

        PopupEnterRoom.SetActive(false);

    }


}
