﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] Transform _point;
    [SerializeField] GameObject _ball;
    [SerializeField] float _speed = 10f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Spawn();
        }        
    }

    public void Spawn()
    {
        GameObject ball = Instantiate(_ball);
        ball.transform.position = _point.position;
        ball.transform.rotation = _point.rotation;
        ball.GetComponent<Rigidbody>().AddForce(ball.transform.forward * _speed, ForceMode.VelocityChange);
        //ball.AddComponent<>();
    }
}