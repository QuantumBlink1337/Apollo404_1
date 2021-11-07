using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehavior : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody cRigidBody;
    private Transform transformer;
    private Terrain terrain;
    [SerializeField] float speed = 3;

    void Start()
    {
        cRigidBody = GetComponent<Rigidbody>();
        transformer = GetComponent<Transform>();
        Debug.Log("Hello World!");
        //transformer.Translate(Vector3.forward);
        //transformer.SetPositionAndRotation(new Vector3(0, 10, 0), Quaternion.identity);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        
        if (Input.GetKey(KeyCode.W))
        {
            cRigidBody.AddForce(new Vector3(speed, 0, 0));
        }

        if (Input.GetKey(KeyCode.S))
        {
            cRigidBody.AddForce((new Vector3(-speed, 0, 0)));
        }

        if (Input.GetKey(KeyCode.A))
        {
            transformer.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * speed, Space.World);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transformer.Rotate(new Vector3(0, -1, 0) * Time.deltaTime * speed, Space.World);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            cRigidBody.AddForce((new Vector3(0, speed, 0)));
        }
        
        if (Input.GetKey(KeyCode.E))
        {
            cRigidBody.AddForce((new Vector3(0, -speed, 0)));
        }
        
    }
}
