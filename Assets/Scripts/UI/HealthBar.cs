using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Image _bar;
    [Range(0f, 1f)]
    [SerializeField] float _offset = 0.006f;
    [SerializeField] int _divisions = 10;
    [SerializeField] float _changeSpeed = 0.4f;
    [SerializeField] SimpleLiveController liveController;
    float _target = 0;

    public void UpdateBar()
    {
        int hp = liveController.GetCurrentLives();
        _target = (1f - _offset) / _divisions * hp + _offset;   
    }

    public void Update()
    {
        if (Mathf.Approximately(_bar.fillAmount, _target) == false)
        {
            _bar.fillAmount = Mathf.MoveTowards(_bar.fillAmount, _target, _changeSpeed * Time.deltaTime);
        }
    }


}
