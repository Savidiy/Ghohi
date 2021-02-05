using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [Header("Vision")]
    [SerializeField] Transform _turretHead;
    [SerializeField] float _seeDistance;    
    [SerializeField] LayerMask _checkLayer;
    GameObject _player;

    [Header("Fire")]
    [SerializeField] float _cooldown;
    [SerializeField] GameObject _bullet;
    [SerializeField] Transform _firePoint;
    [SerializeField] Transform _parent;
    [SerializeField] float _bulletSpeed;
    [SerializeField] float _aimAngle;
    [SerializeField] float _rotateSpeed = 200f;
    [SerializeField] float _bulletLifeTime = 5f;
    float _fireTimer;    

    [Header("Color")]
    [SerializeField] MeshRenderer _meshRenderer;
    [SerializeField] Material _iNoSeeYou;
    [SerializeField] Material _iSeeYou;
    [SerializeField] Material _iAimYou;

    [Header("Sound")]
    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip _fireAudio;
    [SerializeField] AudioClip _rotateAudio;
    [SerializeField] float _rotateSoundPeriod = 0.6f;
    float _rotateSoundTimer;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _fireTimer = 0;
        _rotateSoundTimer = 0;
    }

    void Update()
    {
        if (_fireTimer <= _cooldown)        
            _fireTimer += Time.deltaTime;        
        if (_rotateSoundTimer <= _rotateSoundPeriod)
            _rotateSoundTimer += Time.deltaTime;

        float distance = (_player.transform.position - _turretHead.position).magnitude;
        if (distance < _seeDistance)
        {

            Vector3 origin = _turretHead.position;
            Vector3 direction = _player.transform.position - origin;
            direction.y = 0f;

            //Debug.DrawRay(origin, direction, Color.red, _seeDistance);
            RaycastHit hit;
            bool isSeePlayer = false;
            if (Physics.Raycast(origin, direction, out hit, _seeDistance, _checkLayer))
            {
                //Debug.Log(hit.collider.gameObject.name);
                if(hit.collider.gameObject == _player)
                {
                    isSeePlayer = true;
                }
            }

            if (isSeePlayer)
            {
                // turret see player
                //aim and fire
                float currentAngle = Quaternion.Angle(_turretHead.rotation, Quaternion.LookRotation(direction));
                if (currentAngle < _aimAngle)
                {
                    _meshRenderer.material = _iAimYou;

                    //fire
                    if (_fireTimer > _cooldown)
                    {
                        Fire();
                        _fireTimer = 0;
                    }
                } else
                {
                    _meshRenderer.material = _iSeeYou;
                    if (_rotateSoundTimer > _rotateSoundPeriod)
                    {
                        _audioSource.clip = _rotateAudio;
                        _audioSource.Play();
                        _rotateSoundTimer = 0;
                    }
                }

                // rotate
                Quaternion rot = Quaternion.RotateTowards(
                    from: _turretHead.rotation,
                    to: Quaternion.LookRotation(direction) ,
                    maxDegreesDelta: _rotateSpeed * Time.deltaTime
                    );

                _turretHead.rotation = rot;

            }
            else
            { 
                _meshRenderer.material = _iNoSeeYou; 
            }
        } else
        {
            _meshRenderer.material = _iNoSeeYou;
        }
    }

    void Fire()
    {
        GameObject bullet = Instantiate(_bullet, _parent);
        bullet.transform.position = _firePoint.position;
        bullet.transform.rotation = _firePoint.rotation;
        bullet.GetComponent<Rigidbody>()?.AddForce(bullet.transform.forward * _bulletSpeed, ForceMode.VelocityChange);
        Destroy(bullet, _bulletLifeTime);

        _audioSource.clip = _fireAudio;
        _audioSource.Play();
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(_turretHead.position, _seeDistance);
    }
}
