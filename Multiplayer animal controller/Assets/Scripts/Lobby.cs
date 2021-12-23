using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class Lobby : MonoBehaviourPunCallbacks
{
    public TMP_InputField nameInput;
    public TMP_InputField createInput;
    [Space]
    public byte maxPlayers = 10;
    [Space]
    public Transform contentObject;
    public RoomItem roomItemPrefab;
    [Space]
    public string gameSceneName;

    List<RoomItem> roomItemsList = new List<RoomItem>();

    public void CreateRoom()
    {
        if (createInput.text.Length > 0 && nameInput.text.Length > 0)
        {
            RoomOptions roomOptions = new RoomOptions();
            roomOptions.MaxPlayers = maxPlayers;

            PhotonNetwork.CreateRoom(createInput.text, roomOptions);
        }
        else
        {
            Debug.LogError("Error: please check if the name inputfield and the create room inputfield are not empty!");
        }
    }

    public void JoinRoom(string roomName)
    {
        if (nameInput.text.Length > 0)
        {
            PhotonNetwork.JoinRoom(roomName);
        }
        else
        {
            Debug.LogError("Error: please check if the name inputfield is not empty!");
        }
    }

    public void SaveName()
    {
        PhotonNetwork.NickName = nameInput.text;
    }

    private void Start()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        UpdateRoomList(roomList);
    }

    void UpdateRoomList(List<RoomInfo> list)
    {
        foreach (RoomItem item in roomItemsList)
        {
            Destroy(item.gameObject);
        }
        roomItemsList.Clear();

        foreach (RoomInfo room in list)
        {
            RoomItem newRoom = Instantiate(roomItemPrefab, contentObject);
            newRoom.SetRoomName(room.Name);
            roomItemsList.Add(newRoom);
        }
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel(gameSceneName);
        Debug.Log("Joined room!");
    }

    public void Subscribe()
    {
        Application.OpenURL("https://bit.ly/3EFICZE");
    }

    public void PlayList()
    {
        Application.OpenURL("https://bit.ly/3dyckDI");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
