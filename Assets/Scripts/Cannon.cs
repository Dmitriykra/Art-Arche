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
    public float cannonImpulse = 20f;
    public bool isFired;
    public bool youCanFire = true;
    [SerializeField] AnimationCurve curve;
    float horizontalMove;
    public float moveSpeed = 10f;
    public Manager manager;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0) && !isFired && manager.isPlayble)
        {
            horizontalMove = Input.GetAxis("Mouse X");
        } else
        {
            horizontalMove = 0f;
        }
                
        SideMove();
        if(isFired)
        {
            elapsedTime += Time.deltaTime;
            float percentagecCompl = elapsedTime / backToPosDuration;
            transform.position = Vector3.Lerp(endPosition, startPosition, curve.Evaluate(percentagecCompl));
            if(percentagecCompl >= 1)
            {
                isFired = false;
                elapsedTime = 0;
                youCanFire = true;
                
                
            }
        }
    }

    public void Impuls()
    {
        youCanFire = false;
        rb.velocity = -transform.forward * cannonImpulse;
        StartCoroutine(ReturnToPos());

    }

    IEnumerator ReturnToPos()
    {
        yield return new WaitForSeconds(1);
        endPosition = transform.position;
        isFired = true;
    }
    

    private void SideMove()
    {
        float zAxisMove = transform.position.z + horizontalMove * moveSpeed * Time.deltaTime;
        
        transform.position = new Vector3(transform.position.x, transform.position.y, zAxisMove);
    }

}
