using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    AudioSource audioSource;
    public bool isPlay;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(gameObject!=null && !isPlay && collision.gameObject.tag != "Cnnon")
        {
            audioSource.Play();
        }
        
        Destroy(gameObject, 5f);
    }
    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag != "Cnnon")
        {
            isPlay = true;
        }
        
    }
}
