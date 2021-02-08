using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraRaycastOutline : MonoBehaviour
{
    [SerializeField] CameraAimRaycast _raycaster;
    OutlineController _currentOutline;

    void Update()
    {       
        bool isFindedOutline = false;

        if (_raycaster.AimRaycast(out RaycastHit hitInfo))
        {
            //Debug.Log($"Outline raycast hit {hitInfo.collider.gameObject.name}.");
            var oc = hitInfo.collider.GetComponent<OutlineController>();
            if (oc != null)
            {
                //Debug.Log($"Outline raycast hit OutlineController.");
                isFindedOutline = true;

                if (oc != _currentOutline)
                {
                    //Debug.Log($"Outline raycast hit NEW Outline.");
                    _currentOutline?.OutlineOff();
                    _currentOutline = oc;
                    _currentOutline.OutlineOn();
                }
            }
        }

        if (isFindedOutline == false && _currentOutline != null)
        {
            _currentOutline.OutlineOff();
            _currentOutline = null;
        }
    }
}
