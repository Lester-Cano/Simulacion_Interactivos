using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverRightEJ2 : MonoBehaviour
{
    private IntroMover2 mover;

    // Start is called before the first frame update
    void Start()
    {
        // Create the mover instance
        mover = new IntroMover2();
    }

    // Update is called once per frame
    void Update()
    {
        // Have the mover step and check edges
        mover.Step();
        mover.Step2();
    }
}

public class IntroMover2
{
    public int x, x2;
    public int y, y2;
    float num, num2;
    GameObject sphereMover, sphereMover2;
    List<GameObject> drawnSpheres = new List<GameObject>();

    public IntroMover2()
    {
        sphereMover = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphereMover2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        x = 0;
        y = 0;

        x2 = 0;
        y2 = 0;
    }


    public void Step()
    {
        // Each frame choose a new Random number 0-1;
        num = Random.Range(0f, 1f);

        // The increment direction is decided by our custom probabilities
        if (num < 0.2f) // 20% chance to move up
        {
            y++;
        }
        else if (num > 0.2f && num < 0.4f) // 20% chance to move down
        {
            y--;
        }
        else if (num > 0.4f && num < .6f) // 20% chance to move left
        {
            x--;
        }
        else if (num > .6f) // 40% chance to move right
        {
            x++;
        }
        sphereMover.transform.position = new Vector3(x, y, 0f) * Time.time;
    }

    public void Step2()
    {
        // Each frame choose a new Random number 0-1;
        num2 = Random.Range(0f, 1f);

        // The increment direction is decided by our custom probabilities
        if (num2 < 0.2f) // 20% chance to move up
        {
            y2++;
        }
        else if (num2 > 0.2f && num2 < 0.4f) // 20% chance to move down
        {
            y2--;
        }
        else if (num2 > 0.4f && num2 < .6f) // 20% chance to move left
        {
            x2--;
        }
        else if (num2 > .6f) // 40% chance to move to sphereMover
        {

            Vector3 followPosition = sphereMover.transform.position - sphereMover2.transform.position;

            Debug.Log(followPosition);

            if (followPosition.x > 0) 
            {
                x2--;
            }
            else
            {
                x2++;
            }

            if (followPosition.y > 0)
            {
                y2--;
            }
            else
            {
                y2++;
            }

        }
        sphereMover2.transform.position = new Vector3(x2, y2, 0f) * Time.time;
    }

    // Now let's draw the path of the Mover by creating spheres in its position in the most recent frame.



}
