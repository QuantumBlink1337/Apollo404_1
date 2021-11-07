using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryReceiver : MonoBehaviour
{
    public Collider[] colliders;
    public LaserReceiver receiver;
    [SerializeField] int batteryCollection;
    private const int WIN_CONDITION = 5;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        colliders = Physics.OverlapSphere(transform.position, 50);
        if (colliders.Length != 0)
        {
            //Debug.Log("Found objects");
            foreach (var foundObject in colliders)
            {
                //Debug.Log(foundObject);
                if (foundObject.gameObject.CompareTag("Battery"))
                {
                    //Debug.Log("Found a laser receiver");
                    Debug.Log("Found a battery");
                    Destroy(foundObject.gameObject);
                    batteryCollection++;

                }
            }
            
        }

        if (batteryCollection >= WIN_CONDITION)
        {
            Debug.Log("The player win");
        }
    }
}
