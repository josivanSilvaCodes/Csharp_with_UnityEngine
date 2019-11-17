using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Programa04 : MonoBehaviour
{
    /*
     2° Estrutura Condicional

        Switch Case

        1° dia é o domingo
        2° dia é asegunda-feira
        3° dia é a terça-feira
        ...
     */

    int dia = 1;
    string textoDia = "";

    
    // Start is called before the first frame update
    void Start()
    {
       

       
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            dia = 4;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            dia = 3;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            dia = 1;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            dia = 2;
        }

        switch (dia)
        {
            case 1:
                textoDia = "Norte, tocar animação subindo";
                break;
            case 2:
                textoDia = "Sul, tocar animação descendo";
                break;
            case 3:
                textoDia = "Leste, tocar animação andando para direita";
                break;
            case 4:
                textoDia = "Oeste, tocar animação andando para esquerda";
                break;
            default:
                textoDia = "Direção inválida";
                break;
        }

     
    }

    void OnGUI()
    {
        GUIStyle gui = new GUIStyle(); //instatiate
        gui.fontSize = 30;

        GUI.Label(
            new Rect(20, 20, 520, 520),

            "Dia: " + dia + ", texto: " + textoDia,

            gui
            );
    }
}
