using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    Rigidbody rb;
    Vector3 startPosition;
    Vector3 endPosition;
    float elapsedTime;
    float backToPosDuration = 1f;
    public bool isFired;
    [SerializeField] AnimationCurve curve;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(isFired)
        {
            elapsedTime += Time.deltaTime;
            float percentagecCompl = elapsedTime / backToPosDuration;
            Debug.Log(startPosition + " " + endPosition);
            transform.position = Vector3.Lerp(endPosition, startPosition, curve.Evaluate(percentagecCompl));
            if(percentagecCompl >= 1)
            {
                isFired = false;
                elapsedTime = 0;
            }
        }
    }

    public void Impuls()
    {
        rb.velocity = transform.right * 5f;
        
        StartCoroutine(ReturnToPos());

    }

    IEnumerator ReturnToPos()
    {
        yield return new WaitForSeconds(1);
        endPosition = transform.position;
        isFired = true;
    }

}
