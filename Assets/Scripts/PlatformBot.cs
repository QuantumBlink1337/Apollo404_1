using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBot : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float ThrustMultiplier = 50f;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        ProcessInput();
    }

    void KillMomentum()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.useGravity = !rb.useGravity;
    }

    void ProcessInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            //Thrust();
            gameObject.GetComponent<PlayerController>().charControl.Move(Vector3.up * ThrustMultiplier * Time.deltaTime);

        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("Killing Momentum");
            KillMomentum();
        }
    }

    // void Reverse()
    // {
    //     rb.AddRelativeForce(Vector3.back);
    // }
    void Thrust()
    {
        Debug.Log("Thrusting Baby");
        rb.AddRelativeForce(Vector3.up * ThrustMultiplier);
    }
}
