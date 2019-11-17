using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Programa05 : MonoBehaviour
{
    /*
     Operadore Relacionais e operadores lógicos

     Relacionais
     > maior
     < menor
     >= maior ou igual
     <= menor ou igual
     == exatamente igual
     != diferente

     Lógicos
     && And
     || Or
     ! Not

     */

    float nota1 = 5.0f;
    float nota2 = 5.0f;
    float media = 0.0f;
    string resultado = "";
    int faltas = 26;

    
    // Start is called before the first frame update
    void Start()
    {
              
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            nota1 = nota1 + 1;           
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            nota1 = nota1 - 1;          
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            nota2 = nota2 + 1;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            nota2 = nota2 - 1;
        }

        if (nota1 > 10 || nota1 < 0)
        {
            nota1 = 0;
        }

        if (nota2 > 10 || nota2 < 0)
        {
            nota2 = 0;
        }

        media = (nota1 + nota2) / 2;

        if (media >= 6 && faltas <=25)
        {
            resultado = "APROVADO!";
        }
        else
        {
            resultado = "RETIDO"; 
        }
     
    }

    void OnGUI()
    {
        GUIStyle gui = new GUIStyle(); //instatiate
        gui.fontSize = 30;

        GUI.Label(
            new Rect(20, 20, 520, 520),

            "Nota1: " + nota1 + "\n"+
            "Nota2: " + nota2 + "\n" +
            "Faltas: " + faltas + "% \n" +
            "Média: "+ media + ", " + resultado ,

            gui
            );
    }
}
