using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayerWithOffset : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float offsetX;
    [SerializeField] float offsetY;
    [SerializeField] float offsetZ;

    [SerializeField] bool LookAtMainCamera;

    private void Start()
    {
        if (LookAtMainCamera)
        {
            player = Camera.main.gameObject;
        }
    }
    void Update()
    {
        if (player == null) return;
        transform.LookAt(player.transform);
        transform.Rotate(offsetX, offsetY, offsetZ);
    }
}
