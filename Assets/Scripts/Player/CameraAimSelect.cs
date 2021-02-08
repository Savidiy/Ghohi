using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class CameraAimSelect : MonoBehaviour
{
    [SerializeField] CameraAimRaycast _raycaster;
    [SerializeField] UnityEvent _onChangeSelect;
    [SerializeField] UnityEvent _onSelectOff;
    ISelectController _currentSelect;

    void Update()
    {       
        bool isFindedOutline = false;

        if (_raycaster.AimRaycast(out RaycastHit hitInfo))
        {
            //Debug.Log($"Outline raycast hit {hitInfo.collider.gameObject.name}.");
            var oc = hitInfo.collider.GetComponent<ISelectController>();
            if (oc != null)
            {
                //Debug.Log($"Outline raycast hit OutlineController.");
                isFindedOutline = true;

                if (oc != _currentSelect)
                {
                    ChangeSelect(oc);
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
