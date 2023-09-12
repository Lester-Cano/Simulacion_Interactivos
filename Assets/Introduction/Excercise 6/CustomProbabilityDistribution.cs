using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomProbabilityDistribution : MonoBehaviour
{
    GameObject sphere;
    [SerializeField] float num = 5;

    private void Start()
    {
        sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Walk();
        }
    }


    void Walk()
    {
        num = 5;

        float stepSize = Random.Range(0f, 10f);
        float randomStep = Random.Range(stepSize, stepSize*stepSize);

        float R1 = Random.value;
        float probability = R1;
        float R2 = Random.value;

        if (R2<probability)
        {
            num += randomStep;
        }
        
        float randomMove = Random.Range(0f, 1f);

        if (randomMove < 0.25f)
        {
            sphere.transform.position += new Vector3(num, 0f, 0f);
        }
        else if (randomMove > 0.25f && randomMove < 0.50f)
        {
            sphere.transform.position += new Vector3(0f, 0f, num);
        }
        else if (randomMove > 0.50f && randomMove < 0.75f)
        {
            sphere.transform.position += new Vector3(0f, 0f, -num);
        }
        else if (randomMove > 0.75f)
        {
            sphere.transform.position += new Vector3(-num, 0f, 0f);
        }
    }


}