using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Key", menuName = "Items/Key")]
public class KeySO : ItemSO
{
    public override void UseItem()
    {
        Debug.Log("USE KEY!");
    }

}
