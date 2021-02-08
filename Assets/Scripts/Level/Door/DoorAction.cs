using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAction : MonoBehaviour, IDoAction
{
    [SerializeField] Animator _animator;
    [SerializeField] bool _startOpen = false;

    public void Start()
    {
        if (_startOpen)
        {
            _animator.SetTrigger("setOpen");
        }
        else
        {
            _animator.SetTrigger("setClose");
        } 
    }

    public void DoAction()
    {
        _animator.SetTrigger("changeState");
    }

}
