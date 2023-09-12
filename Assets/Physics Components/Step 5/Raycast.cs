using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    private Mover5_2 mover;
    private rayCastMover raymover;

    void Start()
    {
        mover = new Mover5_2();
        raymover = new rayCastMover();
    }

    void Update()
    {
        mover.Update();
        mover.CheckEdges();
        raymover.lookForFood();
    }
}


public class rayCastMover
{
    private Vector2 location, velocity;
    private GameObject rayMover = GameObject.CreatePrimitive(PrimitiveType.Cube);

    public Vector3 aVelocity = new Vector3(0f, 0f, 0f);
    public Vector3 aAcceleration = new Vector3(0f, 0f, .001f);

    public Rigidbody body;
    private LineRenderer lineRender;

    public rayCastMover()
    {

        rayMover.transform.position = new Vector2(3f, -2f);

        Renderer renderer = rayMover.GetComponent<Renderer>();
        renderer.material = new Material(Shader.Find("Diffuse"));
        renderer.material.color = Color.red;
        body = rayMover.AddComponent<Rigidbody>();
        body.useGravity = false;
        body.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ;

        lineRender = rayMover.AddComponent<LineRenderer>();
        lineRender.material = new Material(Shader.Find("Diffuse"));
        lineRender.widthMultiplier = .01f;

    }

    public void seePrey()
    {
        RaycastHit hit;
        if (Physics.Raycast(rayMover.transform.position, rayMover.transform.up, out hit, Mathf.Infinity))
        {
            lineRender.material.color = Color.white;
            lineRender.SetPosition(0, rayMover.transform.position);
            lineRender.SetPosition(1, hit.transform.position);

            Vector2 escapeVector = Escape(hit.transform.gameObject.GetComponent<Rigidbody>());
            body.AddForce(escapeVector, ForceMode.Impulse);
        }
        else
        {
            lineRender.SetPosition(0, rayMover.transform.position);
            lineRender.SetPosition(1, rayMover.transform.up * 1000);
        }
    }

    public Vector2 Escape(Rigidbody m)
    {
        Vector2 force = m.position - body.position; // Calculate force in the opposite direction
        float distance = force.magnitude;

        distance = Mathf.Clamp(distance, 5f, 25f);
        force.Normalize();
        float strength = (-9.81f * body.mass * m.mass) / (distance * distance);
        force *= strength;
        return force;
    }

    public void lookForFood()
    {
        aVelocity += aAcceleration;
        rayMover.transform.Rotate(aVelocity, Space.World);
        seePrey();
    }
}


public class Mover5_2
{
    private Vector2 location, velocity;
    private Vector2 minimumPos, maximumPos;

    private GameObject mover = GameObject.CreatePrimitive(PrimitiveType.Sphere);
    public Rigidbody body;

    public Mover5_2()
    {
        findWindowLimits();
        location = Vector2.zero;
        velocity = new Vector2(Random.Range(-5, 5), Random.Range(-5, 5));
        body = mover.AddComponent<Rigidbody>();
        body.useGravity = false;
        body.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ;
        Renderer r = mover.GetComponent<Renderer>();
        r.material = new Material(Shader.Find("Diffuse"));
    }

    public void Update()
    {
        velocity = new Vector2(Random.Range(-2, 2), Random.Range(-2, 2));
        location += velocity * Time.deltaTime;
        mover.transform.position = new Vector2(location.x, location.y);
    }

    public void CheckEdges()
    {
        if (location.x > maximumPos.x)
        {
            location.x -= maximumPos.x - minimumPos.x;
        }
        else if (location.x < minimumPos.x)
        {
            location.x += maximumPos.x - minimumPos.x;
        }
        if (location.y > maximumPos.y)
        {
            location.y -= maximumPos.y - minimumPos.y;
        }
        else if (location.y < minimumPos.y)
        {
            location.y += maximumPos.y - minimumPos.y;
        }
    }

    private void findWindowLimits()
    {
        Camera.main.orthographic = true;
        minimumPos = Camera.main.ScreenToWorldPoint(Vector2.zero);
        maximumPos = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }
}
