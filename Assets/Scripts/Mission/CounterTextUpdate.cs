using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CounterTextUpdate : MonoBehaviour
{
    [SerializeField] int _target;
    // [SerializeField] UnityEvent onAdded;
    [SerializeField] UnityEvent onTargetAchieved;
    [SerializeField] bool _isStarted;
    [SerializeField] string template;
    [SerializeField] Text text;

    int _current = 0;
    public int Current { get { return _current; } }

    private void Start()
    {
        UpdateText();
    }

    void Update()
    {
        if(_isStarted && _current >= _target)
        {
            onTargetAchieved.Invoke();
        }
    }

    public void Add(int score)
    {
        if (_isStarted)
        {
            _current += score;
            UpdateText();
            //onAdded.Invoke();
        } else
        {
            Debug.LogWarning("Add Counter then it stopped.");
        }
    }

    public void AddOne()
    {
        if (_isStarted)
        {
            _current += 1;
            UpdateText();
        }
        else
        {
            Debug.LogWarning("Add Counter then it stopped.");
        }
    }

    public void UpdateText()
    {
        string t = template.Replace("%current%", _current.ToString()).Replace("%max%", _target.ToString());
        text.text = t;
    }

    public void ResetCounter()
    {
        _current = 0;
    }
    public void StartCounter()
    {
        _isStarted = true;
    }
    public void StopCounter()
    {
        _isStarted = false;
    }
}
