using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    static public Inventory Instance
    {
        get
        {
            return _instance;
        }
    }
    static private Inventory _instance;

    private List<string> items = new List<string>();
    public UnityEvent OnUpdate;

    private void Awake()
    {
        _instance = this;
    }

    public void AddItem(string itemName)
    {
        //Debug.Log($"Inventory: Add {itemName}");

        items.Add(itemName);
        OnUpdate.Invoke();
    }

    public void DeleteItem(string itemName)
    {
        if (items.Contains(itemName))
        {
            items.Remove(itemName);
            OnUpdate.Invoke();
        }
    }

    public bool HasItem(string itemName)
    {
        return items.Contains(itemName);
    }

    public string[] GetAllItems()
    {
        return items.ToArray();
    }

}
