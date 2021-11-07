using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Animator anims;

    public CharacterController charControl;

    [SerializeField] private Vector2 moveTarget;
    [SerializeField] private int speed = 1;

    public Animator Anims
    {
        get => anims;
        set => anims = value;
    }

    public CharacterController CharControl
    {
        get => charControl;
        set => charControl = value;
    }

    public int Speed
    {
        get => speed;
        set => speed = value;
    }

    [SerializeField] private Vector2 lookTarget;
    [SerializeField] private int sensitivity = 50;
    [SerializeField] private Camera cam;
    //How large the input axis value must be for the player to keep moving
    [SerializeField] private float deadzone;
    
    //Determines Range of Motion for Vertical Look
    [SerializeField] private int maxLook = 75;

    [SerializeField] private float verticalLook;
    
    private Vector3 angles;
    
    // Start is called before the first frame update
    
    void Start()
    {
        charControl = GetComponent<CharacterController>();
        verticalLook = cam.transform.eulerAngles.x;
        Cursor.lockState = CursorLockMode.Locked;
    }
    

    
    // Update is called once per frame
    void Update()
    {
        
        //Looking Code
        if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
        {
            
            //Negative to invert vertical mouse movement
            lookTarget = new Vector2(Input.GetAxis("Mouse X"), -Input.GetAxis("Mouse Y"));
            this.transform.Rotate(0f, lookTarget.x * sensitivity * Time.deltaTime, 0f);
            //Quaternion eulerAngles = Quaternion.Euler(lookTarget.y * sensitivity * Time.deltaTime, 0, 0);
            float oldVert = verticalLook;
            verticalLook += lookTarget.y * sensitivity * Time.deltaTime;
            
            //Debug.Log("BEFORE CLAMP: " + verticalLook);
            verticalLook = Mathf.Clamp(verticalLook, -maxLook, maxLook);
            //Debug.Log("AFTER CLAMP: " + verticalLook);
            //Debug.Log("Vertical look delta: " + (verticalLook - oldVert));
            //cam.transform.Rotate(lookTarget.y * sensitivity * Time.deltaTime, 0, 0);
            
            //Debug.Log(angles.x);
            //float clampedVal = angles.x;
            //logic to find out how to clamp

            //float xRotator = Mathf.Clamp(verticalLook, -0.2f, 0.2f);
            angles = new Vector3(verticalLook, cam.transform.eulerAngles.y, cam.transform.eulerAngles.z);
            cam.transform.rotation = Quaternion.Euler(angles);

            //TODO: FIX JITTERS
            //cam.transform.rotation = Quaternion.Slerp(cam.transform.rotation, Quaternion.Euler(angles), myfloat += Time.deltaTime);
            //Debug.Log("After rotation: " + cam.transform.eulerAngles.x);
        }
        else
        {
            lookTarget = Vector2.zero;
        }
        
        //Walking Code
        
        //if (Math.Abs(Input.GetAxis("Horizontal")) > deadzone || Math.Abs(Input.GetAxis("Vertical")) > deadzone)
        //The above code works with joysticks, but leads to input lag for keyboard
        
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            //DO NOT FORGET TO NORMALIZE THIS BEFORE USING IT
            moveTarget = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
            charControl.Move(transform.TransformDirection(new Vector3(moveTarget.x, 0, moveTarget.y)) * speed * Time.deltaTime);
            anims.SetBool("isWalking", true);
        }
        else
        {
            moveTarget = Vector2.zero;
            anims.SetBool("isWalking", false);
        }

        charControl.Move(Physics.gravity * Time.deltaTime);

        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(cam.ScreenPointToRay(Vector3.zero), out hit, 1000));
            {
                hit.collider.gameObject.SendMessage("OnUsed", this);
            }
        }
    }
}
//TODO: ON CLICK sendmessage()