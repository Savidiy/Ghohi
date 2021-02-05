using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyDownToReloadScene : MonoBehaviour
{
    [SerializeField] KeyCode keyCode;
    void Update()
    {
        if (Input.GetKeyDown(keyCode))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
