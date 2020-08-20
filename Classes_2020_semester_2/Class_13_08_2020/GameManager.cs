using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{   
    Food comida;
    Food lanche;

    void Start()
    {   
        comida = new Food();
        comida.px = 100;
        comida.py = 170;
        comida.size = 100;

        lanche = new Food();
        lanche.px = 350;
        lanche.py = 121;
        lanche.size = 50;
    }

    void Update()
    {
        // PLayer1
        if (Input.GetKeyDown(KeyCode.A))
        {
            comida.Move(-6);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            comida.Move(6);
        }
        
        //Player 2
        if (Input.GetKeyDown(KeyCode.W))
        {
            lanche.size-= 10;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            lanche.size+= 10;
        }
    }


    void OnGUI()
    {
        //GUI.Label(new Rect(30, 50, 100, 100), "score: " + score);
        comida.Draw(comida.px, comida.py, comida.size, Color.green);
        lanche.Draw(lanche.px, lanche.py, lanche.size, Color.red);
    }
}
