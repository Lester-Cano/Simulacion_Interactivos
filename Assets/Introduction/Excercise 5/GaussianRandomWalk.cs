using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaussianRandomWalk : MonoBehaviour
{
    GameObject sphere;

    private void Start()
    {
        sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Walk();
        }
    }


    void Walk()
    {

        float num = Random.Range(Random.Range(-10f, 10f), Random.Range(10f, 10f));
        float standarDeviation = 30f;
        float mean = 5f;

        float x = standarDeviation * num + mean;

        float randomMove = Random.Range(0f,1f);

        if (randomMove < 0.25f)
        {
            sphere.transform.position += new Vector3(x, 0f, 0f);
        }
        else if (randomMove > 0.25f && randomMove < 0.50f)
        {
            sphere.transform.position += new Vector3(0f, 0f, x);
        }
        else if (randomMove > 0.50f && randomMove < 0.75f)
        {
            sphere.transform.position += new Vector3(0f, 0f, -x);
        }
        else if (randomMove > 0.75f)
        {
            sphere.transform.position += new Vector3(-x, 0f, 0f);
        }

    }


}
