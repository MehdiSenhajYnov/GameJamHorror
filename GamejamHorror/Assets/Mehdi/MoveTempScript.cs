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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        currentMoveForce = Vector3.zero;

        if (Input.GetKey(ForwardKey))
        {
            currentMoveForce.z += 1;
        }
        if (Input.GetKey(BackKey))
        {
            currentMoveForce.z -= 1;
        }

        if (Input.GetKey(LeftKey))
        {
            currentMoveForce.x -= 1;
        }
        if (Input.GetKey(RightKey))
        {
            currentMoveForce.x += 1;
        }

        currentMoveForce.Normalize();
        rb.MovePosition(transform.position + currentMoveForce * moveSpeed * Time.deltaTime);

    }
}
