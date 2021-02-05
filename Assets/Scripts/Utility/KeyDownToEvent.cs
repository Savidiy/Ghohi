using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyDownToEvent : MonoBehaviour
{
    [SerializeField] KeyCode keyCode;
    [SerializeField] UnityEvent onKeyDown;
    void Update()
    {
        if (Input.GetKeyDown(keyCode))
        {
            onKeyDown.Invoke();
        }
    }
}

