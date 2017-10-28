using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Achievement1 : MonoBehaviour, IPointerClickHandler
{

    public void OnPointerClick(PointerEventData eventData)
    {
        if (Social.localUser.authenticated)
        {
            Social.ReportProgress("CgkIp9i27cUfEAIQAQ", 100.0f, (bool success) =>
            {
                if (success)
                {
                    Debug.Log("You've successfully logged in");
                }
                else
                {
                    Debug.Log("Login failed for some reason");
                }
            });
        }
    }
}
