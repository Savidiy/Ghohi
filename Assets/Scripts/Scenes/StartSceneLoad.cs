using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneLoad : MonoBehaviour
{
    [SerializeField] string _sceneName;

    void Start()
    {
        SceneSwitcher.Instance.SwitchToScene(_sceneName);
    }

}
