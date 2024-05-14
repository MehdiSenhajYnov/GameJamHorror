using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    Camera cam;
    public PlayerManager playerManager;
    void Start()
    {
        cam = Camera.main;
    }
    [SerializeField] float raydistance = 0.5f;

    [SerializeField] GameObject PickUpButton;
    bool isLookingAtInteractableObject;

    [SerializeField] float offsetMultiplier = 1;
    [SerializeField] Vector3 offsetPosition;

    void Update()
    {
        RaycastHit hit;
        bool result = Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, raydistance);
        if (result && hit.transform.TryGetComponent(out IInteractable interactableObj))
        {
            if (!isLookingAtInteractableObject && interactableObj.showEButton)
            {
                PickUpButton.SetActive(true);
            }
            isLookingAtInteractableObject = true;


            if (Input.GetKeyDown(KeyCode.E))
            {
                interactableObj.Interact();
            }

        } else if (isLookingAtInteractableObject)
        {
            PickUpButton.SetActive(false);
            isLookingAtInteractableObject = false;
        }

        // showing ray
        Vector3 forward = cam.transform.forward * raydistance;
        Debug.DrawRay(cam.transform.position, forward, Color.green);


    }
}

