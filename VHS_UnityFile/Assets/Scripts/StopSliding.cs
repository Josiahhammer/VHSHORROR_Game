using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopSliding : MonoBehaviour
{
    public float friction = 1.0f;

    private Rigidbody rb;
    private Collider col;
    private PhysicMaterial frictionMaterial;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
        frictionMaterial = new PhysicMaterial();
        frictionMaterial.dynamicFriction = friction;
        col.material = frictionMaterial;
    }
}
