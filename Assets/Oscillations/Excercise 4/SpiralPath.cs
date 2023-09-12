using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiralPath : MonoBehaviour
{
    float radius = 2f;
    float theta = 0f;

    private GameObject sphere;
    private MeshRenderer sphereRenderer;

    // Create variables for rendering the line between two vectors
    private GameObject lineDrawing;
    private LineRenderer lineRender;

    // Start is called before the first frame update
    void Start()
    {
        // Set the camera to orthographic and make its size 8
        Camera.main.orthographic = true;
        Camera.main.orthographicSize = 8;

        // Create a GameObject that will be the line
        lineDrawing = new GameObject();

        // Make the sphere as a primitive sphere type.
        sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        // We need to create a new material for WebGL
        sphereRenderer = sphere.GetComponent<MeshRenderer>();
        sphereRenderer.material = new Material(Shader.Find("Diffuse"));

        // Add the Unity Component "LineRenderer" to the GameObject lineDrawing. We will see a black line.
        lineRender = lineDrawing.AddComponent<LineRenderer>();

        // Make the line smaller for aesthetics
        lineRender.startWidth = 0.1f;
        lineRender.endWidth = 0.1f;

        // We need to create a new material for WebGL
        lineRender.material = new Material(Shader.Find("Diffuse"));
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the x and y coordinates of the sphere's position based on the current radius and angle
        float x = radius * Mathf.Cos(theta);
        float y = radius * Mathf.Sin(theta);

        // Update the sphere's position to the new coordinates
        sphere.transform.position = new Vector2(x, y);

        // Increase the radius over time to create the spiral effect
        radius += 0.5f * Time.deltaTime;

        // Increase the angle over time to rotate the spiral
        theta += 1f * Time.deltaTime;

        // Begin rendering the line between the two objects. Set the first point (0) at the centerSphere Position
        // Make sure the end of the line (1) appears at the new Vector3
        Vector2 center = new Vector2(0f, 0f);
        lineRender.SetPosition(0, center);
        lineRender.SetPosition(1, sphere.transform.position);
    }
}