using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public static SceneSwitcher Instance { get { return _instance; } }
    static SceneSwitcher _instance;

    [SerializeField] GameObject _visual;
    [SerializeField] Image _bar;
    [SerializeField] Text[] _texts;
    bool _isLoading = false;
    AsyncOperation _asyncOperation;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Debug.LogError("More one SceneSwither singleton.");
        }
    }

    public void SwitchToScene(string sceneName)
    {
        _asyncOperation = SceneManager.LoadSceneAsync(sceneName);
        _asyncOperation.allowSceneActivation = true;

        _isLoading = true;
        _visual.SetActive(true);

        UpdateUI();
    }

    private void Update()
    {
        if (_isLoading)
        {
            UpdateUI();
        }
    }


    void UpdateUI()
    {
        if (_asyncOperation == null)
        {
            _bar.fillAmount = 0;
            foreach(var t in _texts)
            {
                t.text = "0%";
            }
        }
        else
        {
            float value = _asyncOperation.progress;
            _bar.fillAmount = value;
            string text = Mathf.RoundToInt(value * 100) + "%";
            foreach (var t in _texts)
            {
                t.text = text;
            }
        }
    }
}
