using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float sensX = 100f; // Sensibilité de la souris en X
    public float sensY = 100f; // Sensibilité de la souris en Y

    public float swayAmount = 0.1f; // Amplitude du balancement
    public float swaySmoothness = 1f; // Douceur du balancement

    public Transform orientation;

    float xRotation;
    float yRotation;

    Vector3 initialPosition;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        initialPosition = transform.localPosition;
    }

    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;
        float mouseY = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;

        yRotation += mouseY;
        xRotation -= mouseX;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);

        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            float swayX = Mathf.Sin(Time.time * swaySmoothness) * swayAmount;
            float swayY = Mathf.Cos(Time.time * swaySmoothness * 2) * swayAmount;

            transform.localPosition = initialPosition + new Vector3(swayX, swayY, 0);
        }
        else
        {
            transform.localPosition = initialPosition;
        }
    }
}
