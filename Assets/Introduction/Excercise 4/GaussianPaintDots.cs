using Palmmedia.ReportGenerator.Core.Reporting.Builders;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaussianPaintDots : MonoBehaviour
{
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        
        float col = Random.Range(0f, 1f);

        float num = Random.Range(Random.Range(-10f, 10f), Random.Range(-10f, 10f));
        float sd = 30;
        float mean = 5;

        float x = sd * num + mean;

        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        var sphereRenderer = sphere.GetComponent<Renderer>();

        Color randomPalette = new Color(col, col, col, 1);
        sphereRenderer.material.SetColor("_Color", randomPalette);

        sphere.transform.position = new Vector3(x, 0f, 0f) * Time.deltaTime;


    }

}
