using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneCollision : MonoBehaviour
{
    private void OnTriggerStay(Collider collision)
    {
        // ContactPoint contact = collision.GetContact(0);
        // Quaternion rotation = Quaternion.FromToRotation(Vector3.up, contact.normal);
        // Vector3 position = contact.point;
        GameObject spawnPoint = GameObject.FindWithTag("SpawnPoint");
        //Debug.Log(spawnPoint);
        //Debug.Log("IN THE KILL FLOOR!");
        if (collision.gameObject.CompareTag("Player"))
        {
            //Debug.Log("This is a player");
            //Debug.Log("Player: "+collision.gameObject.transform.position);
            //Debug.Log("SpawnPoint: "+spawnPoint.transform.position);
            //collision.GetComponent<Rigidbody>().velocity = Vector3.zero;
            collision.gameObject.transform.SetPositionAndRotation(spawnPoint.transform.position, Quaternion.identity);
        }
        else
        {
            //Debug.Log("Killed: " + collision.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
