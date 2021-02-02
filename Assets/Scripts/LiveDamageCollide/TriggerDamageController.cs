using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ILiveController))]
[RequireComponent(typeof(Collider))]
public class TriggerDamageController : MonoBehaviour
{ 
    ILiveController liveController;

    private void Start()
    {
        liveController = GetComponent<ILiveController>();
        if (liveController == null)
            Debug.LogError($"{name} can't find ILiveController");
    }

    private void OnTriggerEnter(Collider collider)
    {        
        ILiveController obj2 = collider.gameObject.GetComponent<ILiveController>();

        if (liveController != null && obj2 != null)
        {
            //obj2.HitMe(liveController.Damage);
            liveController.HitMe(obj2.Damage);
        }
    }
}
