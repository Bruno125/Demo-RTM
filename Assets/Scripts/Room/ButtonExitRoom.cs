using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ButtonExitRoom : MonoBehaviour, IPointerClickHandler
{
    public GameObject PanelRoom;
    public GameObject PanelCreateRoom;
    public void OnPointerClick(PointerEventData eventData)
    {
        PanelRoom.SetActive(false);
        PanelCreateRoom.SetActive(true);
        PlayGamesPlatform.Instance.RealTime.LeaveRoom();
    }


}
