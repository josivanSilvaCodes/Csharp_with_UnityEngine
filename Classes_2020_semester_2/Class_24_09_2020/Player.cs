using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : ScriptableObject
{
    private GameObject goPlayer;
    public Camera myCam;

    private Rigidbody myRb;
    public float mySpeed;
    public float MAX_SPEED = 25.0F;

    public void Init()
    {    
       // Debug.Log("Instanciando o Player...");
        goPlayer = Resources.Load("Player") as GameObject;
        goPlayer = Instantiate(goPlayer, 
                         new Vector3(0, 3, 0),
                          Quaternion.identity);

        myRb = goPlayer.GetComponent<Rigidbody>();
        mySpeed = 0.0f;
        
        myCam = Camera.main;
    }

    public void Move()
    {
        goPlayer.transform.Translate(
            0,0, mySpeed * Time.deltaTime, Space.Self);

        float yRotCam = myCam.transform.eulerAngles.y;
        goPlayer.transform.eulerAngles = 
            new Vector3(goPlayer.transform.eulerAngles.x,
                        yRotCam,
                        goPlayer.transform.eulerAngles.z);
    }

    public void ToFront()
    {
        if (mySpeed >= MAX_SPEED) mySpeed = MAX_SPEED;
        else mySpeed += 0.1f;
    }

    public void ToBack()
    {
        if (mySpeed <= -MAX_SPEED) mySpeed = -MAX_SPEED;
        else mySpeed -= 0.1f; 
    }

    public Transform GetTransform()
    {
        return goPlayer.transform;
    }
}
