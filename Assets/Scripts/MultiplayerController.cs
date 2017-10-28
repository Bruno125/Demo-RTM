using UnityEngine;
using System.Collections;
using GooglePlayGames;
using GooglePlayGames.BasicApi.Multiplayer;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
public class MultiplayerController :MonoBehaviour, RealTimeMultiplayerListener 
{
//	public MPLobbyListener lobbyListener;
	private static MultiplayerController _instance = null;
	private uint minimumOpponents = 1;
	private uint maximumOpponents = 1;
	private uint gameVariation = 0;
	private byte _protocolVersion = 1;
	// Byte + Byte + 2 floats for position + 2 floats for velcocity + 1 float for rotZ
	private int _updateMessageLength = 22;
	private List<byte> _updateMessage;

    public GameObject invitationPopup;


    void Start()
    {
        PlayGamesPlatform.Instance.RegisterInvitationDelegate(OnInvitationReceived);
    }
	public string GetMyParticipantId() {
		return PlayGamesPlatform.Instance.RealTime.GetSelf().ParticipantId;


	}

	public List<Participant> GetAllPlayers() {
		return PlayGamesPlatform.Instance.RealTime.GetConnectedParticipants ();
	}

	private void StartMatchMaking() {
		PlayGamesPlatform.Instance.RealTime.CreateQuickGame (minimumOpponents, maximumOpponents, gameVariation, this);
	}
    public void StartRoomCreation()
    {
        PlayGamesPlatform.Instance.RealTime.CreateWithInvitationScreen(minimumOpponents, maximumOpponents, gameVariation, this);
        PlayGamesPlatform.Instance.RealTime.ShowWaitingRoomUI();
    }
    private MultiplayerController() {
		_updateMessage = new List<byte>(_updateMessageLength);
		PlayGamesPlatform.DebugLogEnabled = true;
		PlayGamesPlatform.Activate ();

    }

	private void ShowMPStatus(string message) {
		/*Debug.Log(message);
		if (lobbyListener != null) {
			lobbyListener.SetLobbyStatusMessage(message);
		}*/
	}
	
    public void ShareDividedImage(int imageId, string participantId,int part)
    {
        _updateMessage.Clear();
        _updateMessage.Add(_protocolVersion);
        _updateMessage.Add((byte)'A');
        _updateMessage.AddRange(System.BitConverter.GetBytes(imageId));
        _updateMessage.AddRange(System.BitConverter.GetBytes(part));
        byte[] messageToSend = _updateMessage.ToArray();
        PlayGamesPlatform.Instance.RealTime.SendMessage(true, participantId, messageToSend);
    }
    public void ShareImageToAll(int imageId)
    {
       /* _updateMessage.Clear();
        _updateMessage.Add(_protocolVersion);
        _updateMessage.Add((byte)'A');
        _updateMessage.AddRange(System.BitConverter.GetBytes(imageId));
        byte[] messageToSend = _updateMessage.ToArray();
        PlayGamesPlatform.Instance.RealTime.SendMessageToAll(true, messageToSend);*/
        var list = GetAllPlayers();
        int part = 1;
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].ParticipantId== GetMyParticipantId())
                continue;
            ShareDividedImage(imageId, list[i].ParticipantId, part);
            ++part;

        }
    }
    public void ShareGestureImageToSingle(int imageId,string participantId)
    {
        _updateMessage.Clear();
        _updateMessage.Add(_protocolVersion);
        _updateMessage.Add((byte)'Y');
        _updateMessage.AddRange(System.BitConverter.GetBytes(imageId));
        byte[] messageToSend = _updateMessage.ToArray();
        PlayGamesPlatform.Instance.RealTime.SendMessage(true, participantId,messageToSend);
    }
    public void ShareImage(int imageId,string participantId)
    {
        _updateMessage.Clear();
        _updateMessage.Add(_protocolVersion);
        _updateMessage.Add((byte)'S');
        _updateMessage.AddRange(System.BitConverter.GetBytes(imageId));
        byte[] messageToSend = _updateMessage.ToArray();
        PlayGamesPlatform.Instance.RealTime.SendMessage(true, participantId, messageToSend);
    }
    public void SendChatMessage(string message, string participantId)
    {
        _updateMessage.Clear();
        _updateMessage.Add(_protocolVersion);
        _updateMessage.Add((byte)'M');

        _updateMessage.AddRange(System.BitConverter.GetBytes(message.Length));

        for (int i = 0; i < message.Length; i++)
        {
            var c = message[i];
            _updateMessage.AddRange(System.BitConverter.GetBytes(c));
        }

        byte[] messageToSend = _updateMessage.ToArray();
        PlayGamesPlatform.Instance.RealTime.SendMessage(true, participantId, messageToSend);

    }
    public void SentGestureImageY(float posY,string participantId)
    {
        _updateMessage.Clear();
        _updateMessage.Add(_protocolVersion);
        _updateMessage.Add((byte)'G');

        _updateMessage.AddRange(System.BitConverter.GetBytes(posY));

        byte[] messageToSend = _updateMessage.ToArray();
        //PlayGamesPlatform.Instance.RealTime.SendMessage(true, participantId, messageToSend);
        PlayGamesPlatform.Instance.RealTime.SendMessageToAll(false, messageToSend);
    }
    public void SendMyUpdate(float posX, float posY, Vector2 velocity, float rotZ)
    {
		_updateMessage.Clear ();
		_updateMessage.Add (_protocolVersion);
		_updateMessage.Add ((byte)'U');
		_updateMessage.AddRange (System.BitConverter.GetBytes (posX));  
		_updateMessage.AddRange (System.BitConverter.GetBytes (posY));  
		_updateMessage.AddRange (System.BitConverter.GetBytes (velocity.x));
		_updateMessage.AddRange (System.BitConverter.GetBytes (velocity.y));
		_updateMessage.AddRange (System.BitConverter.GetBytes (rotZ));
		byte[] messageToSend = _updateMessage.ToArray(); 
		Debug.Log ("Sending my update message  " + messageToSend + " to all players in the room");
		PlayGamesPlatform.Instance.RealTime.SendMessageToAll (false, messageToSend);
      //  PlayGamesPlatform.Instance.RealTime.SendMessage(true,)
	}
    
	public void SendRoomName(string participantID)
    {
        _updateMessage.Clear();
        _updateMessage.Add(_protocolVersion);
        _updateMessage.Add((byte)'R');

        var roomName = MainManager.Instance.currentRoomName;
        for (int i = 0; i < roomName.Length; i++)
        {
            var c = roomName[i];
            _updateMessage.AddRange(System.BitConverter.GetBytes(c));
        }
        byte[] messageToSend = _updateMessage.ToArray();
        PlayGamesPlatform.Instance.RealTime.SendMessage(true, participantID, messageToSend);
    }
    public void SendPlayerInfo(string participantID)
    {
        //AvatarID
        //UserName
        //RoomName

        _updateMessage.Clear();
        _updateMessage.Add(_protocolVersion);
        _updateMessage.Add((byte)'I');

        var roomName = MainManager.Instance.currentRoomName;
        var userName = MainManager.Instance.userName;
        var myAvatarId = MainManager.Instance.avatarId;

        _updateMessage.AddRange(System.BitConverter.GetBytes(myAvatarId));

        _updateMessage.AddRange(System.BitConverter.GetBytes(userName.Length));

        for (int i = 0; i < userName.Length; i++)
        {
            var c = userName[i];
            _updateMessage.AddRange(System.BitConverter.GetBytes(c));
        }
        _updateMessage.AddRange(System.BitConverter.GetBytes(roomName.Length));
        for (int i = 0; i < roomName.Length; i++)
        {
            var c = roomName[i];
            _updateMessage.AddRange(System.BitConverter.GetBytes(c));
        }
        

        byte[] messageToSend = _updateMessage.ToArray();
        PlayGamesPlatform.Instance.RealTime.SendMessage(true, participantID, messageToSend);

    }
	public void SignInAndStartMPGame() {
		if (! PlayGamesPlatform.Instance.localUser.authenticated) {
			PlayGamesPlatform.Instance.localUser.Authenticate((bool success) => {
				if (success) {
					Debug.Log ("We're signed in! Welcome " + PlayGamesPlatform.Instance.localUser.userName);
					//StartMatchMaking();
				} else {
					Debug.Log ("Oh... we're not signed in.");
				}
			});
		} else {
			Debug.Log ("You're already signed in.");
			//StartMatchMaking();
		}
	}

	public void SignOut() {
		PlayGamesPlatform.Instance.SignOut ();
	}
	
	public bool IsAuthenticated() {
		return PlayGamesPlatform.Instance.localUser.authenticated;
	}

	public void TrySilentSignIn()
    {
		if (! PlayGamesPlatform.Instance.localUser.authenticated)
        {
			PlayGamesPlatform.Instance.Authenticate ((bool success) =>
            {
				if (success) {
					Debug.Log ("Silently signed in! Welcome " + PlayGamesPlatform.Instance.localUser.userName);

				} else
                {
					Debug.Log ("Oh... we're not signed in.");

                }
			}, true);
		}else 
        {
			Debug.Log("We're already signed in");
		}
	}

	public static MultiplayerController Instance {
		get {
			if (_instance == null) {
				_instance = new MultiplayerController();
			}
			return _instance;
		}
	}

	public void OnRoomSetupProgress (float percent)
	{
		ShowMPStatus ("We are " + percent + "% done with setup");
	}

	public void OnRoomConnected (bool success)
	{
        var players = GetAllPlayers();

        foreach (var player in players)
        {
            if(player.ParticipantId != GetMyParticipantId())
                SendPlayerInfo(player.ParticipantId);
        }
       
        /*if (success) {
			ShowMPStatus ("We are connected to the room! I would probably start our game now.");
			//lobbyListener.HideLobby();
			//lobbyListener = null;
			//Application.LoadLevel("MainGame");
		} else {
			ShowMPStatus ("Uh-oh. Encountered some error connecting to the room.");
		}*/
    }

	public void OnLeftRoom ()
	{
		ShowMPStatus ("We have left the room. We should probably perform some clean-up tasks.");
	}

	public void OnPeersConnected (string[] participantIds)
	{
        var roomName = MainManager.Instance.currentRoomName;

        foreach (string participantID in participantIds)
        {
            SendPlayerInfo(participantID);
            //SendRoomName(participantID);
        }

        /*if (roomName != "")
        {
            foreach (string participantID in participantIds)
            {
                SendRoomName(participantID);
            }
        }*/
	}

    public void OnPeersDisconnected (string[] participantIds)
	{
        var myId = PlayGamesPlatform.Instance.GetUserId();
        
		foreach (string participantID in participantIds)
        {
            MainManager.Instance.OnPlayerLogout(participantID);
		}
	}

    private void OnInvitationReceived(Invitation invitation, bool fromNotification)
    {
        //Generar Popup
        invitationPopup.SetActive(true);
        invitationPopup.GetComponentInChildren<Text>().text = "Invitacion de : " + invitation.Inviter.DisplayName;
        MainManager.Instance.currentInvitation = invitation;

      }
    public void OnRealTimeMessageReceived(bool isReliable, string senderId, byte[] data)
    {
       
        
        byte messageVersion = (byte)data[0];
        char messageType = (char)data[1];
        if (messageType == 'Y')
        {
            int imageId = System.BitConverter.ToInt32(data, 2);
            MainManager.Instance.SharedGestureImageNotification(imageId, senderId);
        }
        if (messageType == 'G')
        {
            float posY = System.BitConverter.ToSingle(data, 2);
            //UpdatearPosicionImagen
            MainManager.Instance.posYGestureReceived = posY;
        }
        if (messageType == 'A')
        {
            int imageId = System.BitConverter.ToInt32(data, 2);
            int imagePart = System.BitConverter.ToInt32(data, 6);

            MainManager.Instance.SharedImageNotification(imageId, senderId,imagePart);
        }
      

        if (messageType == 'M')
        {
            int messageLength = System.BitConverter.ToInt32(data, 2);

            string message = "";

            int byteCounter = 0;

            for (int i = 0; i < messageLength; i++)
            {
                byteCounter = 6 + i * 2;
                char c = System.BitConverter.ToChar(data, 6 + i * 2);
                message += c;
            }
            byteCounter += 2;

            ChatMessage cm = new ChatMessage();
            cm.content = message;
            cm.date = DateTime.Now.ToString();
            cm.senderID = senderId;
            MainManager.Instance.chatMessages[senderId].Add(cm);

            var notificationData = new Hashtable();
            notificationData.Add("chatMessage", cm);
            NotificationCentre.PostNotification(this, "OnChatMessageReceived", notificationData);
        }

        if (messageType == 'I')
        {
            int avatarId = System.BitConverter.ToInt32(data, 2);
            int userNameLength = System.BitConverter.ToInt32(data, 6);

            string userName = "";
            int byteCounter = 0;

            for (int i = 0; i < userNameLength; i++)
            {
                byteCounter = 10 + i * 2;
                char c = System.BitConverter.ToChar(data, 10 + i * 2);
                userName += c;
            }
            byteCounter += 2;

            int roomLength = System.BitConverter.ToInt32(data, byteCounter);
            byteCounter += 4;

            string roomName = "";
            for (int i = 0; i < roomLength; i++)
            {
                char c = System.BitConverter.ToChar(data, byteCounter);
                byteCounter += 2;
                roomName += c;
            }

            if (roomName != "")
            {
                MainManager.Instance.currentRoomName = roomName;

            }

            if (!MainManager.Instance.playersAvatars.ContainsKey(senderId))
                MainManager.Instance.playersAvatars.Add(senderId, avatarId);

            if (!MainManager.Instance.playersUsernames.ContainsKey(senderId))
                MainManager.Instance.playersUsernames.Add(senderId, userName);
            if (!MainManager.Instance.chatMessages.ContainsKey(senderId))
                MainManager.Instance.chatMessages.Add(senderId, new List<ChatMessage>());

            NotificationCentre.PostNotification(this, "OnPlayerInfoUpdated");
            //Updatear ROOM


            //Me esta compartiendo la imagen 
            //Llamar PopUp con la informacion 


        }
    }

    
    public void OnParticipantLeft(Participant participant)
    {
        throw new NotImplementedException();
    }
}
