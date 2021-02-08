using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineController : MonoBehaviour
{
    [SerializeField] int _outlineLayer;
    [SerializeField] int _defaultLayer;
    [SerializeField] GameObject _target;

    public void OutlineOn()
    {
        //Debug.Log("Outline ON");
        _target.layer = _outlineLayer;
    }

    public void OutlineOff()
    {
        //Debug.Log("Outline OFF");
        _target.layer = _defaultLayer;
    }
    

}
