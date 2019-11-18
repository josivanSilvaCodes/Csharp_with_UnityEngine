using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Programa08 : MonoBehaviour
{
    /*
     Array / Vetor / Arranjo

     Uma variável que pode armazenar uma coleção de dados

     Como se fosse uma variável

     Necessita de um índice para controle 

     tipo [ ] nome; ex.: float [] notas;

    nome = new tipo [ tamanho ]; ex.: notas = new float [4];

    float [ ] notas = new float [4];
    notas [0] = 9.0f;
    notas [1] = 4.3f;

    int [ ] valores = {10 , 2, 35, 21, 17}

    

      
     */

    int[] valores = { 7, 3, 21, 4, 32, 29 };
    string resposta = "Em ordem normal: ";
    float[] notas = new float[4];
    float soma = 0;
    float media = 0;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < valores.Length; i++)
        {
            resposta = resposta + valores[i] + ", ";
        }
        Array.Sort(valores);

        resposta = resposta + "\n Em ordem crescente: ";
        for (int i = 0; i < valores.Length; i++)
        {
            resposta = resposta + valores[i] + ", ";
        }

        Array.Reverse(valores);
        resposta = resposta + "\n Em ordem decrescente: ";

        for (int i = 0; i < valores.Length; i++)
        {
            resposta = resposta + valores[i] + ", ";
        }


        notas[0] = 7;
        notas[1] = 8;
        notas[2] = 9.2f;
        notas[3] = .9f;

        for (int j = 0; j < notas.Length; j++)
        {
            soma = soma + notas[j];
        }
        media = soma / notas.Length;

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

            "" + resposta + "\n\n" + 
            "Média das notas: " + media,

            gui
            );
    }
}
