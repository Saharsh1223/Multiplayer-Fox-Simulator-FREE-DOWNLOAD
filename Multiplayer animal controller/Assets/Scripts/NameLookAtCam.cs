using UnityEngine;

public class NameLookAtCam : MonoBehaviour
{
    Transform camera;

    private void Start()
    {
        camera = Camera.main.transform;
    }

    private void Update()
    {
        transform.LookAt(transform.position + camera.rotation * Vector3.forward, camera.rotation * Vector3.up);
    }
}
