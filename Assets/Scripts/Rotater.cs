using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour
{
    [SerializeField] Transform _transform;
    [SerializeField] float _rotateSpeed;

    void Update()
    {
        _transform.RotateAround(_transform.position, Vector3.up,_rotateSpeed * Time.deltaTime);
    }
}
