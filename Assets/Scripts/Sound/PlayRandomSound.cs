using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRandomSound : MonoBehaviour
{
    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip[] _clips;   
    public void Play()
    {
        int index = Random.Range(0, _clips.Length);
        _audioSource.clip = _clips[index];
        _audioSource.Play();
    }
}
