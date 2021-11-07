using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryGenBehavior : MonoBehaviour
{   
    public RaycastHit hit;
    public LaserReceiver receiver;
    public Collider[] colliders;
    private Battery battery;
    [SerializeField] bool powered;
    [SerializeField] private float timer;
    private float waitTime = 10.0f;

    public bool Powered
    {
        get => powered;
        set => powered = value;
    }

    // Start is called before the first frame update
    void Start()
    {
        
        receiver = GameObject.FindGameObjectWithTag("LaserReceiver").GetComponent<LaserReceiver>();
        battery = gameObject.GetComponent<Battery>();
    }

    // Update is called once per frame
    void Update()
    {
        colliders = Physics.OverlapSphere(transform.position, Mathf.Infinity);
        if (colliders.Length != 0)
        {
            Debug.Log("Found objects");
            foreach (var foundObject in colliders)
            {
                //Debug.Log(foundObject);
                if (foundObject.gameObject.CompareTag("LaserReceiver"))
                {
                    Debug.Log("Found a laser receiver");
                    receiver = foundObject.gameObject.GetComponent<LaserReceiver>();
                    if (receiver.Powered)
                    {
                        Debug.Log("Laser is powered.");
                        powered = true;
                    }
                    else
                    {  
                        Debug.Log("Setting Power to false");
                        powered = false;
                    }
                }
            }
            
        }
        else
        {
            Debug.Log("Found nothing.");
        }

        if (powered)
        {
            timer += Time.deltaTime;
            if (timer >= waitTime)
            {
                timer = 0f;
                Debug.Log("Called Function!");
                gameObject.GetComponent<Spawn>().SpawnObject(transform.position+Vector3.forward * 25);
            }
            
        }
    }
}
