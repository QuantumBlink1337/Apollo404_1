using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRobots : MonoBehaviour
{
    [SerializeField] GameObject prefab1;
    [SerializeField] GameObject prefab2;
    public RaycastHit hit;
    public GameObject pickedUpObject;
    public Rigidbody rb;
    [SerializeField] private float dropDistance = 1f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    public void SpawnPlatform(Vector3 spawnPos)
    {
        Debug.Log("spawned Robot!");
        Object.Instantiate(prefab1, spawnPos + Vector3.back, Quaternion.identity);
        
    }
    
    public void SpawnCargo(Vector3 spawnPos)
    {
        Debug.Log("spawned Robot!");
        Object.Instantiate(prefab2, spawnPos + Vector3.back, Quaternion.identity);
        
    }
    

    void ProcessInput()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
            {
                if (hit.collider.gameObject.CompareTag("DynamicObject"))
                {
                    pickedUpObject = hit.collider.gameObject;
                    hit.collider.gameObject.transform.parent = transform;
                    hit.collider.transform.position = transform.position - transform.forward;
                }
            }
        }
        else if (Input.GetKeyUp(KeyCode.F))
        {
            pickedUpObject.transform.parent = null;
            pickedUpObject.transform.position = this.transform.position + transform.forward * dropDistance;
            pickedUpObject = null;
        }
    }
}
