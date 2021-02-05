using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerCollider : MonoBehaviour
{
    [SerializeField] UnityEvent _onEnter;
    [SerializeField] bool _mustCheckTag = true;
    [SerializeField] string _checkedTag = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (_mustCheckTag)
        {
            if (other.gameObject.CompareTag(_checkedTag))
            {
                _onEnter.Invoke();
            }   
        }
        else
        {
            _onEnter.Invoke();
        }
    }
}
