using UnityEngine;
using System.Collections;

public class CharacterCamera : MonoBehaviour
{
    public Transform lookAt;
    public Transform cameraTransform;

    private Camera mainCamera;

    private float distance = 3.0f;
    private float currentX = 0.0f;
    private float currentY = 20.0f;

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
