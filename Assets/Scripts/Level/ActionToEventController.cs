using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActionToEventController : MonoBehaviour, IDoAction
{
    [SerializeField] UnityEvent onDoAction;

    public void DoAction()
    {
        //Debug.Log($"{this.GetType()}: DoAction");

        onDoAction.Invoke();
    }
}
