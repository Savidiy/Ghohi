using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeyboardController : MonoBehaviour
{
    [SerializeField] Transform _target;
    [SerializeField] Transform _lookFrom;
    [SerializeField] float _rotateSpeed = 200f;
    [SerializeField] float _moveSpeed = 1f;


    void Start()
    {
        
    }

    void FixedUpdate()
    {
        float horizontal = -1 * Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if (horizontal != 0 || vertical != 0)
        {
            Vector3 inputDirection = new Vector3(horizontal, 0f, vertical);
            inputDirection.Normalize();

            //rotation
            Vector3 dirLookFrom = _target.position - _lookFrom.position;
            dirLookFrom.y = 0;
            Quaternion direction = Quaternion.FromToRotation(inputDirection, dirLookFrom );
            _target.rotation = Quaternion.RotateTowards(_target.rotation, direction, _rotateSpeed * Time.deltaTime);

            //move
            _target.position = _target.position + _target.forward * _moveSpeed * Time.deltaTime;
        }
    }
}
