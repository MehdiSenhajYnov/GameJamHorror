using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public List<ItemSO> Items { get; private set; }

    public event Action<ItemSO> ItemAdded;  

    public Inventory()
    {
        Items = new List<ItemSO>();
    }

    public void AddItem(ItemSO newItem)
    {
        Debug.Log("New item !");
        Items.Add(newItem);
        ItemAdded?.Invoke(newItem);
    }

    public void RemoveItem(ItemSO itemToRemove)
    {
        if (Items.Contains(itemToRemove))
        {
            Items.Remove(itemToRemove);
        }
    }

}
