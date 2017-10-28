﻿using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ButtonLibrary : MonoBehaviour, IPointerClickHandler
{
    public GameObject PanelLibrary;

    public void OnPointerClick(PointerEventData eventData)
    {
        PanelLibrary.SetActive(true);
    }


}
