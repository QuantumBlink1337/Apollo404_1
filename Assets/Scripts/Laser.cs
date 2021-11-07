using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public RaycastHit hit;
    public LineRenderer lineRender;
    public LaserReceiver receiver;
    // Start is called before the first frame update
    void Start()
    {
        //Put A receiver in the receiver variable so that the else in Update doesnt error out
        receiver = GameObject.FindGameObjectWithTag("LaserReceiver").GetComponent<LaserReceiver>();
        lineRender = GetComponent<LineRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, -transform.forward, out hit, Mathf.Infinity))
        {
            lineRender.positionCount = 2;
            lineRender.SetPosition(0, transform.position);
            lineRender.SetPosition(1, hit.point);
            
            if (hit.collider.gameObject.GetComponent<LaserReceiver>() != null)
            {
                receiver = hit.collider.gameObject.GetComponent<LaserReceiver>();
                receiver.Powered = true;
                //Debug.Log("Found a receiver");
            }
            else
            {
                receiver.Powered = false;
            }
        }
    }

    private void OnDisable()
    {
        receiver.Powered = false;
    }
}
