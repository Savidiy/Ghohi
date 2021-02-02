using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnParticlesEnd : MonoBehaviour
{
    [SerializeField] GameObject _destroyTarget;
    [SerializeField] ParticleSystem _particleSystem;

    bool _startCheck;

    // Update is called once per frame
    void Update()
    {
        if (_startCheck && _particleSystem.particleCount == 0)
        {
            Destroy(_destroyTarget);
        }
    }

    public void StartDestroyCheck()
    {
        _startCheck = true;
    }
}
