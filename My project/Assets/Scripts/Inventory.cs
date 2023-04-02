using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int maxInventorySize = 10;
    private List<GameObject> inventory = new List<GameObject>();

    public void AddItem(GameObject item)
    {
        if (inventory.Count < maxInventorySize)
        {
            inventory.Add(item);
            item.SetActive(false);
            Debug.Log("Added " + item.name + " to inventory.");
        }
        else
        {
            Debug.Log("Inventory is full!");
        }
    }
}