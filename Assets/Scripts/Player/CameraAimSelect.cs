using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class CameraAimSelect : MonoBehaviour
{
    [Header("Select Event")]
    [SerializeField] CameraAimRaycast _raycaster;
    [SerializeField] UnityEvent _onChangeSelect;
    [SerializeField] UnityEvent _onSelectOff;
    [Header("Select Distance")]
    [SerializeField] Transform _observer;
    [SerializeField] float _maxDistance = 1f;

    ISelectController _currentSelect;

    void Update()
    {       
        bool isFindedOutline = false;

        if (_raycaster.AimRaycast(out RaycastHit hitInfo))
        {
            //Debug.Log($"Outline raycast hit {hitInfo.collider.gameObject.name}.");

            //check distance
            if (_observer == null || (_observer != null && Vector3.Magnitude(_observer.position - hitInfo.collider.transform.position) <= _maxDistance))
            {
                var oc = hitInfo.collider.GetComponent<ISelectController>();
                //check select
                if (oc != null)
                {
                    //Debug.Log($"Outline raycast hit OutlineController.");
                    isFindedOutline = true;
                    //check changed selected object
                    if (oc != _currentSelect)
                    {
                        ChangeSelect(oc);
                    }
                }
            }
        }

        if (isFindedOutline == false && _currentSelect != null)
        {
            SelectOff();
        }
    }

    void ChangeSelect(ISelectController select)
    {
        _currentSelect?.SelectOff();
        _currentSelect = select;
        _currentSelect.SelectOn();
        _onChangeSelect.Invoke();
    } 

    void SelectOff()
    {
        _currentSelect.SelectOff();
        _currentSelect = null;
        _onSelectOff.Invoke();
    }

    public void DoAction()
    {
        if (_currentSelect != null)
            _currentSelect.DoAction();
    }
}
