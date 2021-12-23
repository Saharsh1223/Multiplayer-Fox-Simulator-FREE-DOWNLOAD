using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public Transform playerContainer;

    private void Start()
    {
        Vector3 spawnPoint = new Vector3(Random.Range(-5f, 5f), Random.Range(2f, 5f), Random.Range(-5f, 5f));
        SpawnPlayer(spawnPoint);
    }

    void SpawnPlayer(Vector3 spawnPoint)
    {
        GameObject spawnedPlayer = PhotonNetwork.Instantiate(playerPrefab.name, spawnPoint, playerPrefab.transform.rotation);

        spawnedPlayer.transform.SetParent(playerContainer);
    }
}