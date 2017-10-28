using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ButtonSelectDevice : MonoBehaviour, IPointerClickHandler
{
    public GameObject PanelDevice;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (MainManager.Instance.auxImageSelection == -1) return;
        int previousSelection = MainManager.Instance.auxImageSelection;

        var previousImage = MainManager.Instance.GetDeviceImage(previousSelection);
        var temp = previousImage.color;
        temp.a = 1f;
        previousImage.color = temp;


        PanelDevice.SetActive(false);

        NotificationCentre.PostNotification(this,"OnDeviceImageSelected");
    }

}
