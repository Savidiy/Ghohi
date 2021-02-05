using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [Header("Vision")]
    [SerializeField] Transform _turretHead;
    [SerializeField] float _seeDistance;
    [SerializeField] LayerMask _seeObsacles;
    GameObject _player;

    [Header("Fire")]
    [SerializeField] float _cooldown;
    [SerializeField] GameObject _bullet;
    [SerializeField] Transform _firePoint;
    

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        
    }
}
