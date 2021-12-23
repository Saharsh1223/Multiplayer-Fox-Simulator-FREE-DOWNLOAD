using UnityEngine;
using Photon.Pun;

public class Connect : MonoBehaviourPunCallbacks
{
    public GameObject connectPanel;
    public GameObject lobbyPanel;

    void Start()
    {
        Debug.Log("Made by Saharsh's Cool Games, subscribe: https://www.youtube.com/channel/UCe9TmOXm4RLAcDOci2fk5DQ");
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected!");
        connectPanel.SetActive(false);
        lobbyPanel.SetActive(true);
    }
}
