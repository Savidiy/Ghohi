using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class ObstacleDamageController : MonoBehaviour
{
    [SerializeField] LayerMask _obstacles;
    [SerializeField] UnityEvent onTiggerEnter;

    private void OnTriggerEnter(Collider collider)
    {
        int mask = _obstacles.value;
        int bit = 1 << collider.gameObject.layer;
        bool result = (mask & bit) > 0; // correct layer
        //Debug.Log($"mask = {Convert.ToString(mask, toBase: 2)}, bit = {Convert.ToString(bit, toBase: 2)}, result = {result}");

        if (result)
        {
            onTiggerEnter.Invoke();
        }
    }
}
