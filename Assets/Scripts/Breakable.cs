using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    [SerializeField] GameObject _replacement;
    float _breakeFroce = 5f;
    float _collMult = 100f;
    bool isBroken;

    private void OnCollisionEnter(Collision collision)
    {
        if (isBroken) return;
        if (collision.relativeVelocity.magnitude >= _breakeFroce)
        {
            isBroken = true;
            var replacment = Instantiate(_replacement, transform.position, transform.rotation);
            var rbs = replacment.GetComponentsInChildren<Rigidbody>();
            foreach (var rb in rbs)
            {
                rb.AddExplosionForce(collision.relativeVelocity.magnitude * _collMult, collision.contacts[0].point, 2f);
            }
            Destroy(gameObject);
        }
    }

}
