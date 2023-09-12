using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class VectorsPseudocode : MonoBehaviour
{

    public Vector2 v = new Vector2(1, 5);
    public Vector2 u;
    public Vector2 w;


    private void Start()
    {
        u = v * 2f;
        w = (v - u) / 3;

        Debug.Log(u +" " + v + " " + w);
    }
}
