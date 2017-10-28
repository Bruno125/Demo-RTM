using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GooglePlayGames;
using GooglePlayGames.BasicApi.Multiplayer;
public class MainManager : Singleton<MainManager> {

    public string userName;
    public string currentRoomName;
    public int avatarId;
    public List<int> deviceImageIDs = new List<int>();
    public List<Image> deviceImages = new List<Image>();
    public List<int> libraryImageIDs = new List<int>();
    public List<Image> libraryImages = new List<Image>();
    public List<Image> libraryImagesGestures = new List<Image>();
    public int libraryCount = 0;

    public Dictionary<string, int> playersAvatars = new Dictionary<string, int>();
    public Dictionary<string, string> playersUsernames = new Dictionary<string, string>();

    public int librarySelection;
    public int auxImageSelection = -1;

    public Invitation currentInvitation;

    public int sharedImageID;
    public int sharedImagePart;

    public GameObject popupShare;
    public GameObject popupShareGesture;
    public float posYGestureReceived = 0; 
    public Dictionary<string, List<ChatMessage>> chatMessages = new Dictionary<string, List<ChatMessage>>();

    public string gestureTarget;

	// Use this for initialization
	void Start () {
		
	}
    public int GetDevicePhotoID(int index)
    {
        if (index < 0 || index >= deviceImageIDs.Count) return -1;

        return deviceImageIDs[index];
    }
    public int GetLibraryPhotoID(int index)
    {
        if (index < 0 || index >= libraryImageIDs.Count) return -1;

        return libraryImageIDs[index];
    }
    public Image GetDeviceImage(int index)
    {
        if (index < 0 || index >= deviceImages.Count) return null;

        return deviceImages[index];
    }
    public Image GetLibraryImage(int index)
    {
        if (index < 0 || index >= libraryImages.Count) return null;

        return libraryImages[index];
    }
    public void AddImageToLibrary(int imageId)
    {
        if (libraryCount >= 12) return;

        libraryImageIDs[libraryCount] = imageId;
        ++libraryCount;
    }
    public void DeleteImageFromLibrary(int index)
    {
        if (index >= libraryCount ||  index < 0) return;

        libraryImageIDs.RemoveAt(index);
        foreach (var image in libraryImages)
        {
            image.gameObject.SetActive(false);
        }
        --libraryCount;

        for (int i = 0; i < libraryCount; i++)
        {
            libraryImages[i].gameObject.SetActive(true);
            libraryImages[i].sprite = (Sprite)Resources.Load(libraryImageIDs[i].ToString(), typeof(Sprite));
        }
    }
    public void DisplayLibrary()
    {
        for (int i = 0; i < libraryCount; i++)
        {
            libraryImages[i].gameObject.SetActive(true);
            libraryImages[i].sprite = (Sprite)Resources.Load(libraryImageIDs[i].ToString(), typeof(Sprite));
        }
    }
    public void SharedImageNotification(int imageId,string senderId,int part)
    {
        sharedImageID = imageId;
        sharedImagePart = part;
        popupShare.SetActive(true);
        popupShare.GetComponentInChildren<Text>().text = playersUsernames[senderId] + " desea dividir una \n imagen contigo";
        //popupShare.GetComponentInChildren<Image>().sprite = (Sprite)Resources.Load(imageId.ToString(), typeof(Sprite));

    }
    public void SharedGestureImageNotification(int imageId,string senderId)
    {
        sharedImageID = imageId;
        popupShareGesture.SetActive(true);
        popupShareGesture.GetComponentInChildren<Text>().text = playersUsernames[senderId] + " desea compartir una \n imagen contigo via Gesture";
    }
    public void OnPlayerLogout(string playerId)
    {
        playersAvatars.Remove(playerId);
        playersUsernames.Remove(playerId);
        chatMessages.Remove(playerId);
    }
}
