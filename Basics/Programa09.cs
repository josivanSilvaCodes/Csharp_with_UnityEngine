using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Programa09 : MonoBehaviour
{
    /*
       Funções --> Métodos POO

        Função é um bloco de código nomeado
        que pode ser chamado pelo seu nome

        Quando chamado realiza o processamento
        dependendo do que há em seu interior

        pode receber parâmetros (valores)

        pode retornar parâmetros (valores)

        void, int, float, string, bool

        1° criar
        2° chamar

      
     */
    string resposta = "";
    int resultado = 0;
    int w = -25;
    string saida1 = "";
    string saida2 = "";

    int d = 5;
    int e = 7;
    
    // Start is called before the first frame update
    void Start()
    {
        Modulo(w);
        resultado = Soma(d, e);
        saida1 = PouN(21);
        saida2 = PouN(-55);
    }

    // Update is called once per frame
    void Update()
    {
    

    }

    void Modulo(int x)
    {
        if (x < 0)
        {
            x = x * (-1);
        }
        resposta = x.ToString();
    }

    int Soma(int a, int b)
    {
        resultado = (a + b);
        return resultado;
    }

    string PouN(float f)
    {
        string saida="";
        if (f < 0)
        {
            saida = "NEGATIVO";
        }
        else
        {
            saida = "POSITIVO";
        }
        return saida;
    }

   

    void OnGUI()
    {
        GUIStyle gui = new GUIStyle(); //instatiate
        gui.fontSize = 30;

        GUI.Label(
            new Rect(20, 20, 520, 520),

            "Resposta: " + resposta + "\n"+
            "Resultado: " + resultado + "\n"+
            "Saída 1: " + saida1 + "\n"+
            "Saída 2: " + saida2 + "\n",

            gui
            );
    }
}
