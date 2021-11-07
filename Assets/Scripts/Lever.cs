using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    private RaycastHit hit;
    [SerializeField] Laser otherScript;
    [SerializeField] private LineRenderer otherLineRenderer;

    private void Start()
    {
        //Debug.Log("According to all known laws of aviation, ");
        otherScript.enabled = !otherScript.enabled;
        otherLineRenderer.enabled = !otherLineRenderer.enabled;
    }

    void ProcessInput()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            Debug.Log("Pressed C!");
            if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
            {
                if (hit.collider.gameObject.CompareTag("Lever"))
                {
                    Debug.Log("Called Function!");
                    otherScript.enabled = !otherScript.enabled;
                    otherLineRenderer.enabled = !otherLineRenderer.enabled;

                }

            }
        }
    }

    private void Update()
    {
        ProcessInput();
    }
}
