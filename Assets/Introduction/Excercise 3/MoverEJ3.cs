using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverEJ3 : MonoBehaviour
{

    private IntroMover3 mover;
    [SerializeField] GameObject Food;

    // Start is called before the first frame update
    void Start()
    {
        // Create the mover instance
        mover = new IntroMover3();
        mover.Food = Food;
    }

    // Update is called once per frame
    void Update()
    {
        // Have the mover step and check edges
        mover.Step3();
    }
}

public class IntroMover3
{
    public GameObject Food;

    public int x;
    public int y;
    float num;
    GameObject sphereMover;
    List<GameObject> drawnSpheres = new List<GameObject>();

    public IntroMover3()
    {
        sphereMover = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        x = 0;
        y = 0;
    }


    public void Step3()
    {
        // Each frame choose a new Random number 0-1;
        num = Random.Range(0f, 1f);

        // The increment direction is decided by our custom probabilities
        if (num < 0.50f) // 20% chance to move up
        {
            Vector3 followPosition = Food.transform.position - sphereMover.transform.position;

            if (followPosition.x > 0)
            {
                x--;
            }
            else
            {
                x++;
            }

            if (followPosition.y > 0)
            {
                y--;
            }
            else
            {
                y++;
            }
        }
        else if (num > 0.50f && num < 0.66f) // 20% chance to move down
        {
            y--;
        }
        else if (num > 0.66f && num < .82f) // 20% chance to move left
        {
            x--;
        }
        else if (num > .82f) // 40% chance to move right
        {
            x++;
        }
        sphereMover.transform.position = new Vector3(x, y, 0f) * Time.time;
    }
}



    /*
    GameObject Player;

    private void Start()
    {
        Player = GameObject.CreatePrimitive(PrimitiveType.Sphere);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RandomDirection();
        }
    }

    void RandomDirection()
    {

        float num = UnityEngine.Random.Range(0f, 1f);

        if (num < 0.25f)
        {
            Player.transform.position = new Vector3(5f, 1f, 0f);
        }
        else if (num > 0.25f && num < 0.50f)
        {
            Player.transform.position = new Vector3(0f, 1f, 5f);
        }
        else if (num > 0.50f && num < 0.75f)
        {
            Player.transform.position = new Vector3(0f, 1f, -5);
        }
        else if (num > 0.75f)
        {
            Player.transform.position = new Vector3(-5, 1f, 0f);
        }



    }
    */

