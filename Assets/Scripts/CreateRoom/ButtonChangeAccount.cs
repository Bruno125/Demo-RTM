using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ButtonChangeAccount : MonoBehaviour, IPointerClickHandler
{

    public void OnPointerClick(PointerEventData eventData)
    {
        PlayGamesPlatform.Instance.SignOut();
        MultiplayerController.Instance.TrySilentSignIn();
        //PlayGamesPlatform.Instance.RegisterInvitationDelegate()
    }


}
