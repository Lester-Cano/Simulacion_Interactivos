using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DynamicPhysics : MonoBehaviour {

    [SerializeField] public float initialValue;
    [SerializeField] public float max;
    [SerializeField] public float min;

    [SerializeField] public float Friction;
    [SerializeField] public float Bounce;

    PhysicMaterial ChangeableMaterial;


    void Start () {

        ChangeableMaterial = new PhysicMaterial();

        ChangeableMaterial.dynamicFriction = initialValue;
        ChangeableMaterial.staticFriction = initialValue;
        ChangeableMaterial.bounciness = 0;

        gameObject.GetComponent<Collider>().material = ChangeableMaterial;
    }

    private void Update()
    {

        if(Input.GetKeyDown(KeyCode.Space))
        {
            ChangeProps();
        }

    }

    void ChangeProps()
    {
        float randomValue = Random.Range(min, max);
        float randomValue2 = Random.Range(min, max);
        float randomValue3 = Random.Range(min, max);


        ChangeableMaterial.dynamicFriction = randomValue;
        ChangeableMaterial.staticFriction = randomValue2;
        ChangeableMaterial.bounciness = randomValue3 / 10;


        Friction = randomValue;
        Bounce = randomValue3;


    }

}