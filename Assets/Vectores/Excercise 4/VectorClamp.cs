using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorClamp : MonoBehaviour
{

    public Vector2 vector2;
    public float max, maxLenght;

    private void Start()
    {
        float vectorMagnitude = vector2.sqrMagnitude;

        if (vectorMagnitude > max * max)
        {
            float magnitude = Mathf.Sqrt(vectorMagnitude);
            Debug.Log(vector2 / magnitude * maxLenght);
        }
        Debug.Log(vector2);
    }
}


