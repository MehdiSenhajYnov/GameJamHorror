using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem
{
    public string Name;
    public InventoryItem(ItemSO item)
    {
        Name = item.Name;
    }

    public void Use()
    {

    }
}
