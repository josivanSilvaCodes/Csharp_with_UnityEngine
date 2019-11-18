using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Programa06 : MonoBehaviour
{
    /*
     Estrutura de Repetição
        While --> Enquanto

        instruções/processamentos


        while (condição/teste)
        {
            processamento
        }


        contador: um valor inicial de controle e estratégico
        while com um teste válido e relacionado ao contador
        bloco de processamento com repetições
        atualização do contador
        quando sair do teste (teste for falso) segue fluxo normal

     */

    int inicio = 6;
    string resposta = "";
    int fim = -2;
    
    
    // Start is called before the first frame update
    void Start()
    {
        while (inicio >= fim)
        {
            resposta = resposta + inicio.ToString() + "\n";
            inicio = inicio - 1;
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

            "Contagem: " + resposta ,

            gui
            );
    }
}
