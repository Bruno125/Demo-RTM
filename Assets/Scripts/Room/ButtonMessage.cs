using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
public class ButtonMessage : MonoBehaviour  ,IPointerClickHandler
{
    // public GameObject PopupCreateRoom;
    public string playerId;
    public GameObject MessageWindow;
    public ChatMessageManager chatMessageManager;

    public void OnPointerClick(PointerEventData eventData)
    {
        chatMessageManager.currentTargetId = playerId;
        MessageWindow.SetActive(true);
    }
	
}
