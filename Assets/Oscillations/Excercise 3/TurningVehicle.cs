using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurningVehicle : MonoBehaviour
{
    MoverOs mover;

    //Mouse coordinates
    Vector2 inWorldMousePosition;

    float turnSpeed = 10f;
    float moveSpeed = 10f;

    bool movingRight, movingLeft;

    // Start is called before the first frame update
    void Start()
    {
        mover = new MoverOs();
        inWorldMousePosition = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        inWorldMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float gotoRight = Vector3.right.x - mover.location.x;
        float gotoLeft = Vector3.left.x - mover.location.x;

        float angleR = Mathf.Atan2(gotoRight, 0);
        float angleL = Mathf.Atan2(gotoLeft, 0);

        if (movingLeft) 
        {
            mover.TranslateLeft(moveSpeed);
            mover.Rotate(angleL, turnSpeed);
            movingRight = false;
        }
        else if (movingRight) 
        {
            mover.TranslateRight(moveSpeed);
            mover.Rotate(angleR, turnSpeed);
            movingLeft = false;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            movingLeft = true;
            
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            movingRight = true;
            
        }

        
        mover.Update();
    }
}

public class MoverOs
{
    // The basic properties of a mover class
    public Vector2 location, velocity, acceleration;
    public float mass;

    private Vector2 maximumPos;

    private GameObject mover;

    public MoverOs()
    {
        mover = GameObject.CreatePrimitive(PrimitiveType.Cube);

        Renderer renderer = mover.GetComponent<Renderer>();
        renderer.material = new Material(Shader.Find("Diffuse"));
        renderer.material.color = Color.black;

        mover.transform.localScale = new Vector3(0.5f, 1, 0.5f);

        mass = 1;

        location = Vector2.zero;
        velocity = Vector2.zero;
        acceleration = Vector2.zero;

    }

    public void TranslateLeft(float speed)
    {
        velocity = -(Vector2)mover.transform.right * speed;
    }
    public void TranslateRight(float speed)
    {
        velocity = (Vector2)mover.transform.right * speed;
    }

    public void Rotate(float radiansAngle, float turnSpeed)
    {
        float eulerAngle = (-radiansAngle * Mathf.Rad2Deg) + 180;
        float toSpin = eulerAngle - ((mover.transform.eulerAngles.z + 180) % 360);
        if (toSpin > 180 || toSpin < -180)
        {
            toSpin %= 180;
            toSpin *= -1;
        }

        toSpin = Mathf.Clamp(toSpin, -turnSpeed, turnSpeed);
        mover.transform.Rotate(new Vector3(0, 0, toSpin));
    }

    public void Update()
    {
        velocity += acceleration * Time.deltaTime;
        location += velocity * Time.deltaTime;

        acceleration = Vector2.zero;

        mover.transform.position = location;

    }

    
}