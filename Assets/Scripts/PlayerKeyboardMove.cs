using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeyboardMove : MonoBehaviour
{

    [Header("Objects")]
    [SerializeField] Rigidbody _rigidbody;
    //[SerializeField] Transform _target;
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

    void Update()
    {
        //Jump
        if (IsGrounded())
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Vector3 force = Vector3.up * _jumpForce;
                _rigidbody.AddForce(force, ForceMode.VelocityChange);
                _jumpDelayTimer = _jumpDelay;
            }
        }
        else
        {
            _jumpDelayTimer -= Time.deltaTime;
        }
    }
    void FixedUpdate()
    {
        //Move
        float horizontal = -1 * Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if (horizontal != 0 || vertical != 0)
        {            
            Vector3 inputDirection = new Vector3(horizontal, 0f, vertical);
            inputDirection.Normalize();

            //rotation
            Vector3 dirLookFrom = _rigidbody.position - _lookFrom.position;
            dirLookFrom.y = 0;
            Quaternion direction = Quaternion.FromToRotation(inputDirection, dirLookFrom );
            _rigidbody.rotation = Quaternion.RotateTowards(_rigidbody.rotation, direction, _rotateSpeed * Time.deltaTime);

            //move
            _rigidbody.position += _rigidbody.transform.forward * _moveSpeed * Time.deltaTime;
        }
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
