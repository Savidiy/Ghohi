using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraRaycastOutline : MonoBehaviour
{
    private Camera _camera;
    [SerializeField] RectTransform _UItarget;
    [SerializeField] LayerMask _layerMask;
    OutlineController _currentOutline;

    private void Start()
    {
        _camera = Camera.main;
    }


    void Update()
    {       
        Vector3 aimTo = _UItarget.position;
        Ray ray = _camera.ScreenPointToRay(aimTo);

        bool isFindedOutline = false;

        if (Physics.Raycast(ray, out RaycastHit hitInfo, _camera.farClipPlane, _layerMask))
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
