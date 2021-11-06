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
    private float speed;
    
    void Start()
    {
        cRigidBody = GetComponent<Rigidbody>();
        transformer = GetComponent<Transform>();
        Debug.Log("Hello World!");
        //transformer.Translate(Vector3.forward);
        //transformer.SetPositionAndRotation(new Vector3(0, 10, 0), Quaternion.identity);
        speed = 25;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            cRigidBody.velocity = transform.forward * speed;
        }

        if (Input.GetKey((KeyCode.S)))
        {
            cRigidBody.velocity = -transform.forward * speed;
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
            cRigidBody.velocity = transform.up * speed;
        }
        if (Input.GetKey(KeyCode.E))
        {
            cRigidBody.velocity = -transform.up * speed;
        }

        float yDistance = Math.Abs(Terrain.activeTerrain.transform.position.y - transform.position.y);
        Debug.Log(yDistance);
        if (yDistance < 100)
        {
            // robot is kill :(
            Destroy(this);
        }
        //if ()
    }
}
