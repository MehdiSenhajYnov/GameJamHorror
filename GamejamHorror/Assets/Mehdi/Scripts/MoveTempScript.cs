using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTempScript : MonoBehaviour
{
    [SerializeField] string ForwardKey;
    [SerializeField] string BackKey;
    [SerializeField] string LeftKey;
    [SerializeField] string RightKey;

    Rigidbody rb;
    Vector3 currentMoveForce;
    [SerializeField] float moveSpeed;
    [SerializeField] float mouseSensitivity;

    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
    }
    Vector3 playerRotation, cameraRotation;
    private void Update()
    {


        float yRot = Input.GetAxisRaw("Mouse X");
        playerRotation = new Vector3(0, yRot, 0) * mouseSensitivity;
        float xRot = Input.GetAxisRaw("Mouse Y");
        cameraRotation = new Vector3(xRot, 0, 0) * mouseSensitivity;
    }

    void FixedUpdate()
    {
        currentMoveForce = Vector3.zero;

        if (Input.GetKey(ForwardKey))
        {
            currentMoveForce += transform.forward;
        }
        if (Input.GetKey(BackKey))
        {
            currentMoveForce -= transform.forward;
        }

        if (Input.GetKey(RightKey))
        {
            currentMoveForce += transform.right;
        }
        if (Input.GetKey(LeftKey))
        {
            currentMoveForce -= transform.right;
        }

        currentMoveForce.Normalize();
        rb.MovePosition(transform.position + currentMoveForce * moveSpeed * Time.fixedDeltaTime);

        cam.transform.Rotate(-cameraRotation);
        rb.MoveRotation(rb.rotation * Quaternion.Euler(playerRotation));

    }

}
