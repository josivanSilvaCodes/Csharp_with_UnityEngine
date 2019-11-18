using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Programa07 : MonoBehaviour
{
    /*
     Estrutura de Repetição

        For --> Para 

        int k=0;

        for(k=0; k<5; k++) 
        {
            processamento
        }
      
     */

    string resposta = "\n";
    
    // Start is called before the first frame update
    void Start()
    {
        for (int j = 1; j <= 10; j++)
        {
            resposta = resposta + j + "X" + 7 + "=" +(j*7) + "\n";
        }
    }

    // Update is called once per frame
    void Update()
    {
    

    }

    void OnGUI()
    {
        GUIStyle gui = new GUIStyle(); //instatiate
        gui.fontSize = 30;

        GUI.Label(
            new Rect(20, 20, 520, 520),

            "Resposta: " + resposta ,

            gui
            );
    }
}
