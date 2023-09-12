using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.Profiling;

public class NoiseColor : MonoBehaviour
{
    // Width and height of the texture in pixels.
    public int pixWidth;
    public int pixHeight;

    // The origin of the sampled area in the plane.
    public float xOrg;
    public float yOrg;

    // The number of cycles of the basic noise pattern that are repeated
    // over the width and height of the texture.
    public float scale = 1.0F;

    private Texture2D noiseTex;
    private Color[] pix;
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();

        // Set up the texture and a Color array to hold pixels during processing.
        noiseTex = new Texture2D(pixWidth, pixHeight);
        pix = new Color[noiseTex.width * noiseTex.height];
        rend.material.mainTexture = noiseTex;
    }


    private void Update()
    {
        CalcNoise();
    }


    void CalcNoise()
    {
        // For each pixel in the texture...
        float y = 0.0F;
        float sample, sample2;

        while (y < noiseTex.height)
        {
            float x = 0.0F;
            while (x < noiseTex.width)
            {
                float xCoord = xOrg + x / noiseTex.width * scale;
                float yCoord = yOrg + y / noiseTex.height * scale;
                sample = Mathf.PerlinNoise(xCoord, yCoord);
                sample2 = Mathf.PerlinNoise(yCoord, xCoord);
                ChangeColor(sample, sample2);
                pix[(int)y * noiseTex.width + (int)x] = new Color(sample, sample, sample);
                x++;

                // cambio de color con el sample
                
            }
            y++;
        }

        // Copy the pixel data to the texture and load it into the GPU.
        noiseTex.SetPixels(pix);
        noiseTex.Apply();

        

    }

    void ChangeColor(float prmt1, float prmt2)
    {
        rend.material.color = new Color(prmt1, prmt2, Mathf.PerlinNoise(prmt1,prmt2), 1);
        xOrg += Time.deltaTime / noiseTex.height * scale;
        yOrg += Time.deltaTime / noiseTex.height * scale;
    }

    
}