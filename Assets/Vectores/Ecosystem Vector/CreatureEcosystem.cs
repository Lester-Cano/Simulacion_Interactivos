using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureEcosystem : MonoBehaviour
{
    public float acceleration, maxSpeed, speed, accelerationChange;

    public GameObject food;

    

    void Update()
    {

        Vector3 vectorDirection = FindVectorDirection();

        speed += vectorDirection.magnitude * Time.deltaTime;
        speed = Mathf.Clamp(speed, 0f, maxSpeed);

        transform.position += vectorDirection * speed * Time.deltaTime;

    }

    public Vector3 FindVectorDirection()
    {

        Vector3 Direction = Vector3.zero;
        Direction += (food.transform.position - transform.position).normalized * acceleration;
        Direction += Random.insideUnitSphere * accelerationChange;

        return Direction;

    }

}
