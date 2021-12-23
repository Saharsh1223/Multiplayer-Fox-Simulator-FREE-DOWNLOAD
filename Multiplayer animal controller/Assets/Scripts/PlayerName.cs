using UnityEngine;
using TMPro;
using Photon.Pun;

public class PlayerName : MonoBehaviour
{
    public TMP_Text nameText;
    public PhotonView photonView;

    private void Awake()
    {
        if (photonView.IsMine)
        {
            nameText.text = "You";
        }
        else
        {
            nameText.text = photonView.Owner.NickName;
        }
    }
}
