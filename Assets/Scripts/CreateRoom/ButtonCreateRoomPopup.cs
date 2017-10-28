using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ButtonCreateRoomPopup : MonoBehaviour, IPointerClickHandler
{
    public GameObject PanelCreateRoom;
    public GameObject PanelRoom;
    public GameObject PopupCreateRoom;
    public InputField roomName;
    public InputField userName;
    public Image avatar;


    void Start()
    {
        NotificationCentre.AddObserver(this, "OnDeviceImageSelected");
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        string room = roomName.text;
        string user = userName.text;

        PopupCreateRoom.SetActive(false);
        PanelCreateRoom.SetActive(false);
        

        MainManager.Instance.userName = user;
        MainManager.Instance.currentRoomName = room;
        PanelRoom.SetActive(true);

        
    }

    void OnDeviceImageSelected(Notification notification)
    {
        int id = MainManager.Instance.GetDevicePhotoID(MainManager.Instance.auxImageSelection);
        MainManager.Instance.avatarId = id;

        //MainManager.Instance.auxImageSelection = -1;
        avatar.sprite = (Sprite)Resources.Load(id.ToString(), typeof(Sprite));
    }

}
