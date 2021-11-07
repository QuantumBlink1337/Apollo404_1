
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    
    public void SpawnObject(Vector3 spawnPos)
    {
        //Debug.Log("spawned Robot!");
        Instantiate(prefab, spawnPos, Quaternion.identity);
        
    }
    
}