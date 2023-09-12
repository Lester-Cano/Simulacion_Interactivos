using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterRotator : MonoBehaviour
{

    [SerializeField] Vector3 accelerationRotation;
    [SerializeField] Vector3 Velocity;

    // Start is called before the first frame update
    void Start()
    {
        Velocity += accelerationRotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        gameObject.transform.Rotate(Velocity, Space.World);

        if (Input.GetMouseButtonDown(0)) 
        {
            Velocity += accelerationRotation;
        }
        
    }
}
