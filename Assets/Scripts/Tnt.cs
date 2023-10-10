using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tnt : MonoBehaviour
{
    [SerializeField] private float triggerForce = 0.5f;
    private float explosionRadius = 5f;
    private float explosionForce = 600f;
    [SerializeField] private GameObject particles;
    public AudioSource _audioSource;
    public MeshRenderer[] meshRenderers;
    public Manager manager;

    private void Start()
    {
        meshRenderers = GetComponentsInChildren<MeshRenderer>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.relativeVelocity.magnitude >= triggerForce)
        {
            if (!_audioSource.isPlaying)
            {
                playSound();
            }
            
            
            var surraundingObj = Physics.OverlapSphere(
                transform.position, explosionRadius);

            foreach (var obj in surraundingObj)
            {
                var rb = obj.GetComponent<Rigidbody>();
                if(rb == null) continue;
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }
            
            var boom = Instantiate(particles, transform.position, Quaternion.identity);
            //Destroy(gameObject); 
            Destroy(boom, 1f); 

        }
    }

    void playSound()
    {
        manager.DecreaseTntCount(1);
        
        for(int i = 0; i < meshRenderers.Length; i++)
        {
            meshRenderers[i].enabled = false;
        }
        
        _audioSource.Play();

        Destroy(gameObject, 1.5f);
        
        
    }
}
