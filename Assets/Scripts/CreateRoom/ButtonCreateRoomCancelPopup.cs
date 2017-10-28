﻿using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ButtonCreateRoomCancelPopup : MonoBehaviour, IPointerClickHandler
{
    public GameObject PopupCreateRoom;

    public void OnPointerClick(PointerEventData eventData)
    {
        PopupCreateRoom.SetActive(false);
    }

}
