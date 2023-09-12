using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AvalancheImpulse : MonoBehaviour
{
    [SerializeField] public float forceMultiplication;

    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            Rigidbody rb = contact.otherCollider.GetComponent<Rigidbody>();
            if (rb != null)
            {
                float force = collision.impulse.magnitude * forceMultiplication;
                rb.AddForce(contact.normal * force, ForceMode.Impulse);
            }
        }
        forceMultiplication += collision.contacts.Length * 0.5f;
    }
}