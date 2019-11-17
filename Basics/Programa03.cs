using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Programa03 : MonoBehaviour
{
    /*
     Estrutura Condicional

     IF (SE)
     
     Else (Senão)

     */

    string nome = "João";
    float nota1 = 3.4f;
    float nota2 = 6.6f;
    float media = 0.0f;

    string resultado = "";

    int vidas = 3;
    bool vivo = false;

    
    // Start is called before the first frame update
    void Start()
    {
        media = (nota1 + nota2) / 2;

       
    }

    // Update is called once per frame
    void Update()
    {
        if (vidas <= 0)
        {
            vivo = false;
        }
        else
        {
            vivo = true;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            vidas = vidas - 1;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            vidas = vidas + 1;
        }

        if (vivo == true)
        {
            resultado = "O personagem está vivo, pode movimentá-lo!";
        }
        else
        {
            resultado = "Morreu, não tem como movimentar mais.";
        }
    }

    void OnGUI()
    {
        GUIStyle gui = new GUIStyle(); //instatiate
        gui.fontSize = 30;

        GUI.Label(
            new Rect(20, 20, 520, 520),

            /*
            "Aluno: " + nome + "\n"+
            "1° Nota: " + nota1 + " \n" +
            "2° Nota: " + nota2 + "\n" +
            "Média: " + media + "\n" +
            "Situação: " + resultado
            */
            resultado + ", \n"+
            "Vidas: " + vidas,

            gui
            );
    }
}
