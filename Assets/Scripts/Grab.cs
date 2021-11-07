using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Grab : MonoBehaviour
{
    public RaycastHit hit;
    public GameObject pickedUpObject;
    public Rigidbody rb;
    [SerializeField] private float dropDistance = 1f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        ProcessInput();
    }

    void ProcessInput()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
            {
                if (hit.collider.gameObject.CompareTag("Battery"))
                {
                    pickedUpObject = hit.collider.gameObject;
                    hit.collider.gameObject.transform.parent = transform;
                    hit.collider.transform.position = transform.position - transform.forward;
                }
            }
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            pickedUpObject.transform.parent = null;
            pickedUpObject.transform.position = this.transform.position + transform.forward * dropDistance;
            pickedUpObject = null;
        }
    }
}
