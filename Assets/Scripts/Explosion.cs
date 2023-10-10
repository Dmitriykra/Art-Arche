using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private AudioSource _audioSource;
    
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayExploSound()
    {
        Debug.Log("Explosion!2");
        _audioSource.Play();
    }
}
