using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonOscilation : MonoBehaviour
{

    Rigidbody rb;
    [SerializeField] Vector3 CanonForce, rotationForce;
    public bool rotateOn = false;


    void Start()
    {
        
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {

            rb.isKinematic= false;
            rb.AddForce(CanonForce);
            rotateOn = true;

        }

        if (rotateOn)
        {
            ApplyRotation();
        }

    }

    void ApplyRotation()
    {
        transform.Rotate(rotationForce);
    }
}
