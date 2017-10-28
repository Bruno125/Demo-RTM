using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ChatMessageManager : MonoBehaviour {

    public string currentTargetId;
    public Text targetName;
	// Use this for initialization
	void Start ()
    {
	
        NotificationCentre.AddObserver(this, "OnChatMessageSent");
        NotificationCentre.AddObserver(this, "OnChatMessageReceived");
    }

    void OnChatMessageReceived(Notification notification)
    {
        ChatMessage chatMessage = notification.data["chatMessage"] as ChatMessage;

        if (!this.gameObject.activeInHierarchy) return;

        var original = Resources.Load("Prefabs/MessagePanel");
        var newGameObject = (GameObject)GameObject.Instantiate(original);
        newGameObject.transform.SetParent(this.gameObject.transform);

        //newGameObject.transform.FindChild("Sender").GetComponent<Text>().text = MainManager.Instance.playersUsernames[chatMessage.senderID];
        //newGameObject.transform.FindChild("Date").GetComponent<Text>().text = chatMessage.date;
        newGameObject.transform.FindChild("Content").GetComponent<Text>().text = chatMessage.content;
        newGameObject.transform.FindChild("Sender").GetComponent<Text>().text = MainManager.Instance.playersUsernames[chatMessage.senderID];
        newGameObject.transform.FindChild("Date").GetComponent<Text>().text = chatMessage.date;
    }
    void OnChatMessageSent(Notification notification)
    {
        ChatMessage chatMessage = notification.data["chatMessage"] as ChatMessage;
        if (!this.gameObject.activeInHierarchy) return;

        var original = Resources.Load("Prefabs/MessagePanel");
        var newGameObject = (GameObject)GameObject.Instantiate(original);
        newGameObject.transform.SetParent(this.gameObject.transform);

        //newGameObject.transform.FindChild("Sender").GetComponent<Text>().text = MainManager.Instance.playersUsernames[chatMessage.senderID];
        //newGameObject.transform.FindChild("Date").GetComponent<Text>().text = chatMessage.date;
        newGameObject.transform.FindChild("Content").GetComponent<Text>().text = chatMessage.content;
        newGameObject.transform.FindChild("Sender").GetComponent<Text>().text = MainManager.Instance.userName;
        newGameObject.transform.FindChild("Date").GetComponent<Text>().text = DateTime.Now.ToString();


    }
        void OnEnable()
    {
        targetName.text = MainManager.Instance.playersUsernames[currentTargetId];
        //Refrescar lista mensajes
        var messages = MainManager.Instance.chatMessages[currentTargetId];

        for(int i = 0; i < transform.childCount; i++)
        {
           var child = transform.GetChild(i);
           Destroy(child.gameObject);
        }

        foreach (var message in messages)
        {
            var original = Resources.Load("Prefabs/MessagePanel");
            var newGameObject = (GameObject)GameObject.Instantiate(original);
            newGameObject.transform.SetParent(this.gameObject.transform);
            newGameObject.transform.FindChild("Content").GetComponent<Text>().text = message.content;
            newGameObject.transform.FindChild("Sender").GetComponent<Text>().text = MainManager.Instance.playersUsernames[message.senderID];
            newGameObject.transform.FindChild("Date").GetComponent<Text>().text = message.date;
        }
    }
}
