using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeyboardMove : MonoBehaviour
{

    [Header("Objects")]
    [SerializeField] Rigidbody _rigidbody;
    [SerializeField] Transform _lookFrom;
    [Header("Move")]
    [SerializeField] float _rotateSpeed = 200f;
    [SerializeField] float _moveSpeed = 1f;
    [Header("Jump")]
    [SerializeField] float _jumpForce = 200f;
    [SerializeField] float _jumpDelay = 0.1f;
    [Header("Ground Collider")]
    [SerializeField] Vector3 _sphereOffset;
    [SerializeField] float _sphereRadius;
    [SerializeField] LayerMask _groundLayerMask;

    float _jumpDelayTimer;
    bool _doJump;
    float _horizontal = 0;
    float _vertical = 0;

    void Update()
    {
        #region Jump
        if (IsGrounded())
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _doJump = true;                
            }
        }
        else
        {
            _jumpDelayTimer -= Time.deltaTime;
        }
        #endregion


        #region Move
        _horizontal = -1 * Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");
        
        #endregion
    }

    private void FixedUpdate()
    {
        #region Jump
        if (_doJump)
        {
            Vector3 force = Vector3.up * _jumpForce;
            _rigidbody.AddForce(force, ForceMode.VelocityChange);
            _jumpDelayTimer = _jumpDelay;
            _doJump = false;
        }
        #endregion

        #region Move
        if (_horizontal != 0 || _vertical != 0)
        {
            Vector3 inputDirection = new Vector3(_horizontal, 0f, _vertical);
            inputDirection.Normalize();

            //rotation
            Vector3 dirLookFrom = _rigidbody.position - _lookFrom.position;
            dirLookFrom.y = 0;
            Quaternion direction = Quaternion.FromToRotation(inputDirection, dirLookFrom);
            _rigidbody.rotation = Quaternion.RotateTowards(_rigidbody.rotation, direction, _rotateSpeed * Time.fixedDeltaTime);

            //move
            _rigidbody.position += _rigidbody.transform.forward * _moveSpeed * Time.fixedDeltaTime;
        }
        else
        {
            _rigidbody.position += Vector3.zero;
        }

        #endregion
    }

    private void OnDrawGizmos()
    {
        if (IsGrounded())
            Gizmos.color = Color.green;
        else
            Gizmos.color = Color.red;
        Gizmos.DrawSphere(SpherePosition(), _sphereRadius);        
    }

    Vector3 SpherePosition()
    {
        return _rigidbody.transform.position + _rigidbody.rotation * _sphereOffset;
    }
    bool IsGrounded()
    {
        if (_jumpDelayTimer < 0)
        {
            Collider[] colliders = Physics.OverlapSphere(SpherePosition(), _sphereRadius, _groundLayerMask);
            return colliders.Length > 0;
        }
        return false;
    }

}
