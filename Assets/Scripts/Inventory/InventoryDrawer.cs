using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDrawer : MonoBehaviour
{
    [SerializeField] Text _text;
    [SerializeField] [TextArea] string _firstString;
    [SerializeField] [TextArea] string _itemPrefix;
    [SerializeField] [TextArea] string _itemSuffix;


    void Start()
    {
        //Debug.Log($"InventoryDrawer: Start");
        Inventory.Instance.OnUpdate.AddListener(Redraw);
        Redraw();
    }

    void Redraw()
    {
        //Debug.Log($"InventoryDrawer: Redraw");

        var items = Inventory.Instance.GetAllItems();

        string text = _firstString;
        foreach (var i in items)
        {
            text += $"{_itemPrefix}{i}{_itemSuffix}";
        }
        _text.text = text;
    }

}
