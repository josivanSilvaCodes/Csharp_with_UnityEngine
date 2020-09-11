using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Camera myCam;
    //private int speed = 10;
    
    Rigidbody m_Rigidbody;
    float m_speed;

    void Start()
    {
        //Fetch the Rigidbody component you attach from your GameObject
        m_Rigidbody = GetComponent<Rigidbody>();
        //Set the speed of the GameObject
        m_speed = 0.0f;
    }

    public void Update()
    {
        Move();
    }

    public void Move()
    {
        
        transform.Translate(0, 0, m_speed * Time.deltaTime, Space.Self);
        
       // Vector3 Movement = new Vector3 (Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
     
       // transform.position += Movement * speed * Time.deltaTime;
       
       if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
       {
           //Move the Rigidbody forwards constantly at speed you define (the blue arrow axis in Scene view)
           if (m_speed >= 3) m_speed = 3;
           else m_speed+=0.1f;
       }

       if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S) )
       {
           //Move the Rigidbody backwards constantly at the speed you define (the blue arrow axis in Scene view)
           if (m_speed <= -3) m_speed = -3f;
           else m_speed-=0.1f;
       }

      
        float yRotationCam = myCam.transform.eulerAngles.y;
        transform.eulerAngles = new Vector3( transform.eulerAngles.x, yRotationCam, transform.eulerAngles.z );
     
    }
}
