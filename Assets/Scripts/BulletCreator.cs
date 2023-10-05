using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCreator : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletVelocity = 100f;
    [SerializeField] GameObject fire;
    [SerializeField] AudioClip audioClip;
    [SerializeField] Cannon canonScript;
    [SerializeField] Manager manager;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    

    public void FireButton()
    {
        if(manager.isPlayble && canonScript.youCanFire)
        {
            ShootImpulse();

            GameObject newBullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            Rigidbody newBulletRb = newBullet.GetComponent<Rigidbody>();
            newBulletRb.velocity = transform.forward * bulletVelocity;

            var fireEffect = Instantiate(fire, transform.position, transform.rotation.normalized);

            audioSource.PlayOneShot(audioClip);
            
            Destroy(fireEffect, 1.5f);
        }
    }

    void  ShootImpulse()
    {
        canonScript.Impuls();
    }
}
