using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientCondition : MonoBehaviour
{
    private ParticleSystem windParticles;
    public float windForce = 10.0f;
    WindZone wind;

    void Start()
    {
        windParticles = GetComponent<ParticleSystem>();

        wind = GetComponent<WindZone>();

        wind.transform.parent = windParticles.transform;
        wind.transform.localPosition = new Vector3(-5.0f, 0f, 0.0f);
        wind.GetComponent<WindZone>().mode = WindZoneMode.Spherical;

        ParticleSystem.MainModule mainModule = windParticles.main;
        mainModule.startColor = Color.white;
    }

    void Update()
    {
        var externalForces = windParticles.externalForces;
        externalForces.enabled = true;
        //While we cannot give the wind a force, we can assign an external force to the Wind from
        //the particle system
        externalForces.multiplier = windForce;
        //Now let's change how blustery it is

        if (Input.GetKeyDown(KeyCode.H))
        {
            wind.windMain = 0;
            windForce = Random.Range(1f, 15f);
            Color hot = Color.red;
            ParticleSystem.MainModule mainModule = windParticles.main;
            mainModule.startColor = hot;
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            wind.windMain = 10;
            windForce = Random.Range(15f, 30f);
            Color mild = Color.cyan;
            ParticleSystem.MainModule mainModule = windParticles.main;
            mainModule.startColor = mild;
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            wind.windMain = -10;
            windForce = Random.Range(30f, 50f);
            Color cold = Color.blue;
            ParticleSystem.MainModule mainModule = windParticles.main;
            mainModule.startColor = cold;
        }
    }



    
}