using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nave : ScriptableObject
{

    private GameObject goNave;

    public int posx;
    public int posy;
    public float velx;
    public float vely;
    
    
    public void Init()
    {
        posx = -3;
        posy = -2;
        velx = 1;
        vely = 1;
        
        goNave = Resources.Load("spaceship") as GameObject;
        goNave = Instantiate(goNave,
            new Vector2(posx, posy),
            Quaternion.identity);
  
    }

    public void Move()
    {
        goNave.transform.position = 
            new Vector3(posx, posy,
                goNave.transform.position.z);
    }

    public void TurnLeft()
    {
        posx = posx - 1;
    }

    public void TurnRight()
    {
        posx = posx + 1;
    }
}
