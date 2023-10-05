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
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.relativeVelocity.magnitude >= triggerForce)
        {
            _audioSource.Play();
            
            var surraundingObj = Physics.OverlapSphere(
                transform.position, explosionRadius);

            foreach (var obj in surraundingObj)
            {
                var rb = obj.GetComponent<Rigidbody>();
                if(rb == null) continue;
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }
            
            var boom = Instantiate(particles, transform.position, Quaternion.identity);
            Destroy(gameObject); 
            Destroy(boom, 1f); 

        }
    }
}
