using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Room : MonoBehaviour
{
    public GameObject userPanel;
    public Text roomName;
    public Image userAvatar;
    public Text userName;
    
    public List<GameObject> othersPanels;
    public List<Image> othersAvatars;
    public List<Text> othersUsernames;

	// Use this for initialization
	void Start ()
    {
        NotificationCentre.AddObserver(this, "OnPlayerInfoUpdated");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnEnable()
    {
       // var userNameLabel = userPanel.GetComponentInChildren<Text>();
        //var userAvatar = userPanel.GetComponentInChildren<Image>();

        userName.text = MainManager.Instance.userName;
        roomName.text = MainManager.Instance.currentRoomName;
        userAvatar.sprite = (Sprite)Resources.Load(MainManager.Instance.avatarId.ToString(), typeof(Sprite));

        
    }

    void OnPlayerInfoUpdated(Notification notification)
    {
        
        userName.text = MainManager.Instance.userName;
        roomName.text = MainManager.Instance.currentRoomName;

        int i = 0;
        foreach (var key in MainManager.Instance.playersAvatars.Keys)
        {
            var avatarID = MainManager.Instance.playersAvatars[key];
            othersAvatars[i].sprite = (Sprite)Resources.Load(avatarID.ToString(), typeof(Sprite));
            ++i;
        }

        i = 0;
        foreach (var key in MainManager.Instance.playersUsernames.Keys)
        {
            var playerName = MainManager.Instance.playersUsernames[key];
            othersUsernames[i].text = playerName;
            othersPanels[i].transform.FindChild("ButtonMessage").GetComponent<ButtonMessage>().playerId =
                key;
            othersPanels[i].transform.FindChild("ButtonCompartir").GetComponent<ButtonShareGesture>().playerId =
                key;
            ++i;
        }
    }
}
