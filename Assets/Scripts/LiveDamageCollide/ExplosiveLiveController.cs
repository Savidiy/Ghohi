using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class ExplosiveLiveController : MonoBehaviour
{
    [SerializeField] int _damage = 1;

    private void OnTriggerEnter(Collider collider)
    {
        ILiveController target = collider.gameObject.GetComponent<ILiveController>();

        if (target != null)
        {
            target.HitMe(_damage);
        }
    }

}
