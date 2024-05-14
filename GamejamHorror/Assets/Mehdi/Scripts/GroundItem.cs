using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundItem : MonoBehaviour, IInteractable
{
    public ItemSO ItemSO;
    public PlayerManager playerManager;
    [field:SerializeField] public bool showEButton { get; set; } = true;

    public void Interact()
    {
        playerManager.PlayerInventory.AddItem(ItemSO);
        Destroy(gameObject);
    }
}
