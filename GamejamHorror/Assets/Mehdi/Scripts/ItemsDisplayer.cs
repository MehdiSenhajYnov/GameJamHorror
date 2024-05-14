using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemsDisplayer : MonoBehaviour
{
    [SerializeField] PlayerManager playerManager;

    [SerializeField] GameObject itemParent;
    [SerializeField] GameObject itemPrefab;

    [SerializeField] bool currentState = false;

    void Start()
    {
        playerManager.PlayerInventory.ItemAdded += OnItemAdded;
    }

    private void OnItemAdded(ItemSO sO)
    {
        GameObject item = Instantiate(itemPrefab);
        item.name = "item"+sO.name;
        item.transform.SetParent(itemParent.transform);
        item.transform.GetChild(0).GetComponent<Image>().sprite = sO.Sprite;
        item.transform.GetChild(1).GetComponent<TMP_Text>().text = sO.Name;

        item.GetComponent<Button>().onClick.AddListener(() =>
        {
            sO.UseItem();
        });
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            if (!currentState)
            {
                currentState = true;
                ChangeALlChildVisibility(true);
            }
        } else if (currentState)
        {
            currentState = false;
            ChangeALlChildVisibility(false);
        }
    }

    void ChangeALlChildVisibility(bool newState)
    {
        foreach (Transform t in transform)
        {
            t.gameObject.SetActive(newState);
        }
    }
}
