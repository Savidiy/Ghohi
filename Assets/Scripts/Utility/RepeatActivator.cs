using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RepeatActivator : MonoBehaviour
{
    [SerializeField] float _delay;
    [SerializeField] bool isPlayOnStart;
    [SerializeField] UnityEvent _onPlay;
    [SerializeField] UnityEvent _onTime;
    float _timer = 0;
    bool _isPlayed = false;

    private void Start()
    {
        if (isPlayOnStart)
            Play();
    }

    void Update()
    {
        if (_isPlayed)
        {
            _timer += Time.deltaTime;
            if (_timer >= _delay)
            {
                _onTime.Invoke();
                _isPlayed = false;
                _timer = 0;
            }
        }
    }

    public void Play()
    {
        _timer = 0;
        _isPlayed = true;
        _onPlay.Invoke();
    }
}
