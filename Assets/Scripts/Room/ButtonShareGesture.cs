using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ButtonShareGesture : MonoBehaviour, IPointerClickHandler
{
    public string playerId;

    public GameObject PanelBibliotecaGesture;
    public void OnPointerClick(PointerEventData eventData)
    {
        MainManager.Instance.gestureTarget = playerId;
        //PanelRoom.SetActive(false);
        PanelBibliotecaGesture.SetActive(true);
    }


}
