using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Player p;
    private ThirdCamera tc;
    
    // Start is called before the first frame update
    void Start()
    {
        
        
        p = ScriptableObject.CreateInstance<Player>();
        p.Init();

        tc = ScriptableObject.CreateInstance<ThirdCamera>();
        tc.target = p.GetTransform();
        tc.Init();

        p.myCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {  
        p.Move();

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            p.ToFront();
        }
        
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            p.ToBack();
        }
    }

    private void LateUpdate()
    {
        tc.CamMove();
        tc.CamLook();
    }
}
