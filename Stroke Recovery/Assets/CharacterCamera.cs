using UnityEngine;
using System.Collections;

public class CharacterCamera : MonoBehaviour
{
    public Transform lookAt;
    public Transform cameraTransform;

    private Camera mainCamera;

    private float distance = 2.0f;
    private float currentX = 5.0f;
    private float currentY = 35.0f;
    //private float sensivityX = 1.0f;
    //private float sensivityY = 1.0f;

    private void Start()
    {
        cameraTransform = transform;
        mainCamera = Camera.main;
    }

    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        cameraTransform.position = lookAt.position + rotation * dir;
    }
}
