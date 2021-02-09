using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HasItemAction : MonoBehaviour, IDoAction
{
    [SerializeField] string _itemName;
    [SerializeField] UnityEvent _onHaveItem;
    [SerializeField] UnityEvent _onHaveNotItem;

    public void DoAction()
    {
        if (Inventory.Instance.HasItem(_itemName))
        {
            _onHaveItem.Invoke();
        }
        else
        {
            _onHaveNotItem.Invoke();
        }
    }
}
