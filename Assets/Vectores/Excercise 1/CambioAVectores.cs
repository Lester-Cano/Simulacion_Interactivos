using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.FilePathAttribute;

public class CambioAVectores : MonoBehaviour
{
    private IntroMover32 mover;
    [SerializeField] GameObject Food;

    // Start is called before the first frame update
    void Start()
    {
        // Create the mover instance
        mover = new IntroMover32();
        mover.Food = Food;
    }

    // Update is called once per frame
    void Update()
    {
        // Have the mover step and check edges
        mover.Step3();

        mover.CheckEdges();
    }
}

public class IntroMover32
{
    

    public GameObject Food;

    private Vector3 location;


    private Vector2 maximumPos;

    float num;
    GameObject sphereMover;
    List<GameObject> drawnSpheres = new List<GameObject>();

    public IntroMover32()
    {
        FindWindowLimits();

        sphereMover = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        
    }


    public void Step3()
    {
        // Each frame choose a new Random number 0-1;
        num = Random.Range(0f, 1f);
        location = sphereMover.transform.position;
        // The increment direction is decided by our custom probabilities
        if (num < 0.50f) // 20% chance to move up
        {
            Vector3 followPosition = Food.transform.position - sphereMover.transform.position;

            if (followPosition.x > 0)
            {
                location.x--;
            }
            else
            {
                location.x++;
            }

            if (followPosition.y > 0)
            {
                location.y--;
            }
            else
            {
                location.y++;
            }
        }
        else if (num > 0.50f && num < 0.66f) // 20% chance to move down
        {
            location.y--;
        }
        else if (num > 0.66f && num < .82f) // 20% chance to move left
        {
            location.x--;
        }
        else if (num > .82f) // 40% chance to move right
        {
            location.x++;
        }
        sphereMover.transform.position += location * Time.deltaTime;
    }
    public void CheckEdges()
    {
        location = sphereMover.transform.position;
        // Reset location to zero upon reaching maximum or(||) negative maximum(minimum)
        if (location.x > maximumPos.x || location.x < -maximumPos.x)
        {
            location = Vector2.zero;
        }
        if (location.y > maximumPos.y || location.y < -maximumPos.y)
        {
            location = Vector2.zero;
        }
        // Set the position of the mover to location
        sphereMover.transform.position = location;

    }

    private void FindWindowLimits()
    {
        // We want to start by setting the camera's projection to Orthographic mode
        Camera.main.orthographic = true;
        // Next we grab the maximum position for the screen
        maximumPos = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        // The maximum position can be attributed to the minimum bounds by setting it negative
        // maximumPos and -maximumPos equate to maximum and minimum screen bounds
    }
}