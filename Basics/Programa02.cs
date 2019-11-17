using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Programa02 : MonoBehaviour
{
    /*
     OPERADORES ARITMÉTICOS

        Adição +
        Subtração -
        Multiplicação *
        Divisão /

        Mod %

     */

    float numero1;
    float numero2;

    float resposta1;
    float resposta2;
    float resposta3;
    float resposta4;

    string resultado = "";

    
    // Start is called before the first frame update
    void Start()
    {
        numero1 = 100.0f;
        numero2 = 20.0f;

        /*
        resposta = (numero1 + numero2);
        resultado = "Soma: " + resposta.ToString();

        resposta = (numero1 - numero2);
        resultado = resultado + ", Sub: " + resposta.ToString();

        resposta = (numero1 * numero2);
        resultado = resultado + ", Mult: " + resposta.ToString();

        resposta = (numero1 / numero2);
        resultado = resultado + ", Div: " + resposta.ToString();
        */

        resposta1 = (numero1 + numero2);
        resposta2 = (numero1 - numero2);
        resposta3 = (numero1 * numero2);
        resposta4 = (numero1 / numero2);

        resultado =
            "Número1: " + numero1 + " e " + "Número2: " + numero2 + "\n\n" +
            "Soma: " + resposta1 + ", \n" +
            "Sub:  " + resposta2 + ", \n" +
            "Mult: " + resposta3 + ", \n" +
            "Div:  " + resposta4;


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

            resultado,

            gui
            );
    }
}
