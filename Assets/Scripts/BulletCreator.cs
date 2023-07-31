using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCreator : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletVelocity = 20f;
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

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && manager.isPlayble)
        {
            ShootImpulse();

            GameObject newBullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            newBullet.GetComponent<Rigidbody>().velocity = transform.forward * bulletVelocity;

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
