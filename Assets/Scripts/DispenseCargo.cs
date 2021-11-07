using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispenseCargo : MonoBehaviour
{
    public RaycastHit hit;
    private SpawnRobots otherScript;
    private void Start()
    {
        otherScript = gameObject.GetComponent<SpawnRobots>();
    }

    private void Update()
    {
        ProcessInput();
    }

    void ProcessInput()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
            {
                if (hit.collider.gameObject.CompareTag("CargoDispenser"))
                {
                    Debug.Log("Called Function!");
                    otherScript.SpawnCargo(hit.collider.gameObject.transform.position);
                }

            }
        }
    }
}