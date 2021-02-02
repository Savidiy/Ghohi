using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SimpleLiveController : MonoBehaviour, ILiveController
{
    int _currentLives = 1;
    [SerializeField] int _maxLives = 1;
    [SerializeField] int _damage = 1;
    [SerializeField] UnityEvent onDead;

    private void Start()
    {
        ResetLives();
    }

    public int Damage
    {
        get { return _damage; }
        private set { _damage = value; }
    }

    public void GetHit(int incomeDamage)
    {
        _currentLives -= incomeDamage;
        if (_currentLives <= 0)
        {
            onDead.Invoke();
        }
    }
    public void ResetLives()
    {
        _currentLives = _maxLives;
    }

    public void SetCurrentLives(int lives)
    {
        _currentLives = lives;
    }

    public void DestroyObject(GameObject obj)
    {
        Destroy(obj);
    }

    public int GetCurrentLives()
    {
        return _currentLives;
    }
}
