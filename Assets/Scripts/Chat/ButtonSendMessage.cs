using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using GooglePlayGames;
using GooglePlayGames.BasicApi.Multiplayer;

public class ButtonSendMessage : MonoBehaviour ,IPointerClickHandler
{
    public InputField messageInput;
    public ChatMessageManager chatMessageManager;

    void Start()
    {

    }
    public void OnPointerClick(PointerEventData eventData)
    {
        MultiplayerController.Instance.SendChatMessage(messageInput.text, chatMessageManager.currentTargetId);

        var chatMessage = new ChatMessage();
        chatMessage.content = messageInput.text;
        chatMessage.senderID = PlayGamesPlatform.Instance.GetUserId();
        chatMessage.date = DateTime.Now.ToString();
        MainManager.Instance.chatMessages[chatMessageManager.currentTargetId].Add(chatMessage);

        var data = new Hashtable();
        data.Add("chatMessage", chatMessage);
        NotificationCentre.PostNotification(this, "OnChatMessageSent",data);

        messageInput.text = "";
    }


}
