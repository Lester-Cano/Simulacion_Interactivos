using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Centipede : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] float frequency;
    [SerializeField] float magnitude;


    [SerializeField] float time;


    private void Start()
    {
        time = 0f;
    }

    void Update()
    {

        Vector3 currentPosition = transform.position;
        Vector3 displacement = getDisplacement();
        currentPosition += displacement;

        transform.position = currentPosition;
    }


    Vector3 getDisplacement()
    {
        Vector3 displacement;

        time += Time.deltaTime * frequency;

        Vector3 direction = new Vector3(Mathf.Cos(time) * magnitude, Mathf.Sin(time) * magnitude, 0.0f);

        direction.Normalize();

         displacement = direction * speed * Time.deltaTime;

        return displacement;
    }
}