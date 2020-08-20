using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : ScriptableObject
{
    private GameObject goTiro;
    public float posx;
    public float posy;
    
  
    public void Init()
    {
        posx = 0;
        posy = -4;
        
        goTiro = Resources.Load("bullet") as GameObject;
        goTiro = Instantiate(goTiro,
            new Vector2(posx, posy),
            Quaternion.identity);
    }

    public void Move()
    {
        this.ToFront();
        goTiro.transform.position = 
            new Vector3(posx,
                        posy,
                        goTiro.transform.position.z );
    }

    private void ToFront()
    {
        //posy = posy + 0.1f;
        posy += 0.1f;
    }
}
