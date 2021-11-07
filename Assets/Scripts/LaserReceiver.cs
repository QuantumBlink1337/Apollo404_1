using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserReceiver : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] bool powered;
 

    public bool Powered
    {
        get => powered;
        set => powered = value;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
