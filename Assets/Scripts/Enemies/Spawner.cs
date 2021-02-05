using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject _enemy;
    [SerializeField] GameObject _point1;
    [SerializeField] GameObject _point2;
    [SerializeField] float _firstDelay = 0;
    [SerializeField] float _period = 2;
    [SerializeField] int _spawnLimit = 1;
    [SerializeField] bool _isWorking = true;
    [SerializeField] CounterTextUpdate _infoTarget;

    float _timer = 0;
    float _spawnAmount = 0;

    private void Start()
    {
        _timer = _period - _firstDelay;
    }

    void Update()
    {
        if (_isWorking)
        {
            _timer += Time.deltaTime;

            if (_timer > _period)
            {
                _timer -= _period;

                _spawnAmount++;

                Spawn();

                if (_spawnAmount >= _spawnLimit)
                {
                    _isWorking = false;
                }
            }
        }
    }

    void Spawn()
    {
        GameObject obj = Instantiate(_enemy, transform);

        float x = Random.Range(_point1.transform.position.x, _point2.transform.position.x);
        float y = Random.Range(_point1.transform.position.y, _point2.transform.position.y);
        float z = Random.Range(_point1.transform.position.z, _point2.transform.position.z);

        obj.transform.position = new Vector3(x, y, z);

        var s = obj.GetComponentInChildren<SimpleLiveController>();
        if (s != null)
            s.onDead.AddListener(_infoTarget.AddOne);
    }
    public void SetSpawnLimit(int spawnLimit)
    {
        _spawnLimit = spawnLimit;
    }
    public void StartSpawn() 
    {
        _isWorking = true;
    }
    public void StopSpawn() 
    {
        _isWorking = false;
    }
}
