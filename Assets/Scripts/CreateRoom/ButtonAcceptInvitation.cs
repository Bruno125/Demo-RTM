using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ButtonAcceptInvitation : MonoBehaviour, IPointerClickHandler
{
    // public GameObject PanelDevice;

    public GameObject PanelCreateRoom;
    public GameObject PanelRoom;
    public GameObject PopupInvitation;
    public InputField userName;
    public Image avatar;


    void Start()
    {
        NotificationCentre.AddObserver(this, "OnDeviceImageSelected");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        
        MainManager.Instance.userName = userName.text;
        PopupInvitation.SetActive(false);
        PanelCreateRoom.SetActive(false);
        PanelRoom.SetActive(true);

        var invitation = MainManager.Instance.currentInvitation;
      
        PlayGamesPlatform.Instance.RealTime.AcceptInvitation(invitation.InvitationId, MultiplayerController.Instance);

    }

    void OnDeviceImageSelected(Notification notification)
    {
        int id = MainManager.Instance.GetDevicePhotoID(MainManager.Instance.auxImageSelection);
        MainManager.Instance.avatarId = id;

       
        avatar.sprite = (Sprite)Resources.Load(id.ToString(), typeof(Sprite));
    }
}