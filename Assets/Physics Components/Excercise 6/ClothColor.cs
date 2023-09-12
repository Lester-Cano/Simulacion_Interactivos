using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothColor : MonoBehaviour
{


    SkinnedMeshRenderer skin;


    void Start()
    {
        skin = GetComponent<SkinnedMeshRenderer>();
        skin.material.color = Color.red;

    }
    
      private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Obstacle")
            {
                skin.material.color = Color.blue;
            }
        }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle")
        {
            skin.material.color = Color.blue;

        }
    }
}
