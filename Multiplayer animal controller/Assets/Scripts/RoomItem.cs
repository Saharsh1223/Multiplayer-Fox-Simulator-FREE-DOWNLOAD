using UnityEngine;
using Photon.Pun;
using TMPro;
using Michsky.UI.ModernUIPack;

public class RoomItem : MonoBehaviour
{
    public ButtonManagerBasic button;

    Lobby lobby;

    private void Start()
    {
        lobby = FindObjectOfType<Lobby>();
    }

    public void SetRoomName(string roomName)
    {
        button.buttonText = roomName;
    }

    public void ClickJoin()
    {
        lobby.JoinRoom(button.buttonText);
        Debug.Log("Joining room...");
    }
}
