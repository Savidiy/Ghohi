using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryProvider : MonoBehaviour
{
    public void AddItem(string itemName)
    {
        //Debug.Log($"InventoryProvider: Add {itemName}");
        Inventory.Instance.AddItem(itemName);
    }
    public void DeleteItem(string itemName)
    {
        Inventory.Instance.DeleteItem(itemName);
    }
}
