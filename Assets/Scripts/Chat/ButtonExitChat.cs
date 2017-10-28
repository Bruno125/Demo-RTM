using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ButtonExitChat: MonoBehaviour, IPointerClickHandler
{
    public GameObject chatWindow;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        chatWindow.SetActive(false);
    }
}
