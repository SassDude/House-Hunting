using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform playerBody;

    float xRoatation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // get mouse input
        float mouseX = Input.GetAxis("Mouse X") * sensX * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensY * Time.deltaTime;

        xRoatation -= mouseY;

        xRoatation = Mathf.Clamp(xRoatation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRoatation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);


    }
}
