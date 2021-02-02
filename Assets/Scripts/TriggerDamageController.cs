using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ILiveController))]
[RequireComponent(typeof(Collider))]
public class TriggerDamageController : MonoBehaviour
{
    [SerializeField] LayerMask _obstacles;
    ILiveController liveController;

    private void Start()
    {
        liveController = GetComponent<ILiveController>();
    }

    private void OnTriggerEnter(Collider collider)
    {        
        ILiveController obj2 = collider.gameObject.GetComponent<ILiveController>();

        if (liveController != null && obj2 != null)
        {
            liveController.GetHit(obj2.Damage);
        }

        int mask = _obstacles.value;
        int bit = 1 << collider.gameObject.layer;
        bool result = (mask & bit) > 0; // correct layer
        //Debug.Log($"mask = {Convert.ToString(mask, toBase: 2)}, bit = {Convert.ToString(bit, toBase: 2)}, result = {result}");

        if (result)
        {
            liveController.GetHit(liveController.GetCurrentLives());
        }
    }


}
