using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramovment : MonoBehaviour
{
    public float senseCam;

    public Transform playerBody;

    float xRotation;
    float yRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * senseCam;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * senseCam;

        xRotation -= mouseY;
        yRotation += mouseX;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation,yRotation, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

    }
}
