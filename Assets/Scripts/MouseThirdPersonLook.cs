using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseThirdPersonLook : MonoBehaviour
{
    [Header("Observer and Target")]
    [SerializeField] Transform _lookFrom;
    [SerializeField] Transform _lookTo;
    [Header("Limits")]
    [Range(-85f, 85f)][SerializeField] float _xRotationMax = 85f;
    [Range(-85f, 85f)][SerializeField] float _xRotationMin = -10f;
    [Header("Obstacles")]
    [SerializeField] float _maxDistance = 4f;
    [SerializeField] float _castSphereRadius = 0.08f;
    [SerializeField] LayerMask _layerMask;
    [Header("Settings")]
    [Min(0.01f)][SerializeField] float _mouseSensitivity = 2f;
    [SerializeField] Vector3 _offset;
    [SerializeField] bool _lockCursorOnStart;

    Vector3 _prevLookToPosition;

    void Start()
    {
        if(_lockCursorOnStart)
            Cursor.lockState = CursorLockMode.Locked;

        Vector3 target = _lookTo.position + _offset;
        _prevLookToPosition = _lookTo.position;
        _lookFrom.LookAt(target);
    }

    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Cursor.lockState = CursorLockMode.None;
                
        // move object with target
        Vector3 deltaPos = _lookTo.position - _prevLookToPosition;
        _lookFrom.Translate(deltaPos);

        Vector3 target = _lookTo.position + _offset;
        _lookFrom.LookAt(target);

        float horizontal = Input.GetAxis("Mouse X") * _mouseSensitivity;
        _lookFrom.RotateAround(target, Vector3.up, horizontal); // left-right

        float vertical = -1 * Input.GetAxis("Mouse Y") * _mouseSensitivity;

        float xRotation = _lookFrom.rotation.eulerAngles.x;
        if (xRotation > 180f) xRotation -= 360f; // range -180 ... +180        
        if (vertical + xRotation > _xRotationMax) vertical = _xRotationMax - xRotation;
        if (vertical + xRotation < _xRotationMin) vertical = _xRotationMin - xRotation;

        _lookFrom.RotateAround(target, Vector3.Cross(Vector3.up, target - _lookFrom.position), vertical); // up-down

        // correct distance
        Vector3 direction = _lookFrom.position - target;
        direction.Normalize();
        RaycastHit raycastHit;
        if (Physics.SphereCast(target, _castSphereRadius, direction, out raycastHit, _maxDistance, _layerMask))
        {
            _lookFrom.position = target + direction * raycastHit.distance;
        } 
        else
        {
            _lookFrom.position = target + direction * _maxDistance;
        }

        // save prev position
        _prevLookToPosition = _lookTo.position;
    }
}
