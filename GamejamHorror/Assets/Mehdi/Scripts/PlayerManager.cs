using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Inventory PlayerInventory { get; private set; }

    void Awake()
    {
        PlayerInventory = new Inventory();
    }
    
    void Update()
    {

    }
}
