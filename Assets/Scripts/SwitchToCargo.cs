using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchToCargo : MonoBehaviour
{
    [SerializeField] private Grab otherScript;
    private void Start()
    {
        gameObject.GetComponent<Grab>();
    }

    void OnUsed(PlayerController p)
    {
        p.gameObject.GetComponent<Grab>().enabled = !p.gameObject.GetComponent<Grab>().enabled;
    }
}
