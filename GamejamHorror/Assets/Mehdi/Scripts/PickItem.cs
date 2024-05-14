using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickItem : MonoBehaviour
{
    Camera cam;
    public PlayerManager playerManager;
    void Start()
    {
        cam = Camera.main;
    }
    [SerializeField] float raydistance = 0.5f;

    [SerializeField] GameObject PickUpButton;
    bool isLookingAtItem;

    [SerializeField] float offsetMultiplier = 1;
    [SerializeField] Vector3 offsetPosition;

    void Update()
    {
        RaycastHit hit;
        bool result = Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, raydistance);
        if (result && hit.transform.TryGetComponent(out GroundItem item))
        {
            if (!isLookingAtItem)
            {
                PickUpButton.SetActive(true);
            }
            isLookingAtItem = true;


            if (Input.GetKeyDown(KeyCode.E))
            {
                playerManager.PlayerInventory.AddItem(item.ItemSO);
                Destroy(item.gameObject);
            }

        } else if (isLookingAtItem)
        {
            PickUpButton.SetActive(false);
            isLookingAtItem = false;
        }

        // showing ray
        Vector3 forward = cam.transform.forward * raydistance;
        Debug.DrawRay(cam.transform.position, forward, Color.green);


    }


}
