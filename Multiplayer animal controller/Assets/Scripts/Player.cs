using UnityEngine;
using Photon.Pun;
using TMPro;
using MalbersAnimations;
using MalbersAnimations.Controller;
using MalbersAnimations.Events;
using MalbersAnimations.Utilities;

public class Player : MonoBehaviour
{
    [Header("Name")]
    [SerializeField] TMP_Text nameText;

    [Header("Camera Target")]
    public GameObject cameraTargetObject;

    [Header("Disable Scripts")]
    [SerializeField] PhotonView photonView;
    [Space]
    [SerializeField] MalbersInput malbersInput;
    [SerializeField] MAnimal mAnimal;
    [SerializeField] Stats stats;
    [SerializeField] MDamageable mDamageable;
    [SerializeField] MEventListener mEventListener;
    [SerializeField] LookAt lookAt;
    [SerializeField] Aim aim;
    [Space]
    [SerializeField] UnityEventRaiser unityEventRaiser;
    [Space]
    [SerializeField] BlendShape blendShape;
    [SerializeField] MaterialChanger materialChanger;
    [SerializeField] ActiveMeshes activeMeshes;
    [SerializeField] StepsManager stepsManager;

    MFreeLookCamera mFreeLookCamera;

    private void Start()
    {
        if (photonView.IsMine)
        {
            nameText.text = "You";
            gameObject.tag = "Animal";

            mFreeLookCamera = FindObjectOfType<MFreeLookCamera>();
            Invoke("AfterStart", 0.1f);
        }
        else
        {
            nameText.text = photonView.Owner.NickName;
            //gameObject.tag = "OtherAnimal";
        }
    }

    void AfterStart()
    {
        if (photonView.IsMine)
        {
            mFreeLookCamera.Target_Set(cameraTargetObject.transform);
        }
        if (!photonView.IsMine)
        {
            mFreeLookCamera.Target_Set(cameraTargetObject.transform);
        }
    }

    private void Update()
    {
        DisableScripts();
    }

    void DisableScripts()
    {
        if (!photonView.IsMine)
        {
            malbersInput.enabled = false;
            mAnimal.enabled = false;
            stats.enabled = false;
            mDamageable.enabled = false;
            mEventListener.enabled = false;
            lookAt.enabled = false;
            aim.enabled = false;

            //unityEventRaiser.enabled = false;

            blendShape.enabled = false;
            materialChanger.enabled = false;
            activeMeshes.enabled = false;
            stepsManager.enabled = false;
        }
    }
}
