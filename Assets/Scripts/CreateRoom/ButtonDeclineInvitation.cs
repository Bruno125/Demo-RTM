using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ButtonDeclineInvitation : MonoBehaviour, IPointerClickHandler
{
    // public GameObject PanelDevice;

    public GameObject PanelCreateRoom;
    public GameObject PanelRoom;
    public GameObject PopupInvitation;
    public InputField userName;
    public Image avatar;

    public void OnPointerClick(PointerEventData eventData)
    {
        PopupInvitation.SetActive(false);
    }


}