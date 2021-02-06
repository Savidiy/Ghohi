using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneProvider : MonoBehaviour
{
    public void LoadSceneSingle(string sceneName)
    {
        SceneSwitcher.Instance.SwitchToScene(sceneName);
    }
    public void ReloadThisScene()
    {
        SceneSwitcher.Instance.SwitchToScene(SceneManager.GetActiveScene().name);
    }
}
