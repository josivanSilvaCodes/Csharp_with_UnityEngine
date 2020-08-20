using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
     Nave nave;
     Tiro tiro;
    
    // Start is called before the first frame update
    void Start()
    {
        nave = ScriptableObject.CreateInstance<Nave>();
        nave.Init();
        nave.posx = 0;
        nave.posy = -4;
    }

    // Update is called once per frame
    void Update()
    {
        nave.Move();
        if (tiro != null)
        {
            tiro.Move();
        }
        
        if (Input.GetKeyDown(KeyCode.LeftArrow)
            || Input.GetKeyDown(KeyCode.A))
        {
            nave.TurnLeft();
        }
        
        if (Input.GetKeyDown(KeyCode.RightArrow)
            || Input.GetKeyDown(KeyCode.D))
        {
            nave.TurnRight();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            tiro = ScriptableObject.CreateInstance<Tiro>();
            tiro.Init();
            tiro.posx = nave.posx;
 
        }
    }
}
