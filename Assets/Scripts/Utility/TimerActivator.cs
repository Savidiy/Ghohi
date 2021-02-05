using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimerActivator : MonoBehaviour
{
    [SerializeField] float _delay;
    [SerializeField] UnityEvent _onStart;
    [SerializeField] UnityEvent _onTime;
    float _timer = 0;

    private void Start()
    {
        _onStart.Invoke();
    }

    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= _delay)
        {
            _onTime.Invoke();
            Destroy(this);
        }
    }
}
