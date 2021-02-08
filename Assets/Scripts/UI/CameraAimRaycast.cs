using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAimRaycast : MonoBehaviour
{
    private Camera _camera;
    [SerializeField] RectTransform _UItarget;
    [SerializeField] LayerMask _layerMask;

    private void Start()
    {
        _camera = Camera.main;
    }

    public bool AimRaycast(out RaycastHit hitInfo)
    {
        Vector3 aimTo = _UItarget.position;
        Ray ray = _camera.ScreenPointToRay(aimTo);

        bool result = Physics.Raycast(ray, out hitInfo, _camera.farClipPlane, _layerMask);

        return result;
    }
}
