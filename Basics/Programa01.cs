using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Programa01 : MonoBehaviour
{
    string nome = "Mario";
    int vidas = 5;
    float poder = 62.3f;
    bool vivo = true;

    int a = 3;
    int b = 7;

    float nota1 = 5.0f;
    float nota2 = 5.0f;
    float media = 0.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        media = (nota1 + nota2) / 2;
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

            "Aluno: "+ nome +"\n"+
            "Nota 1: "+ nota1 +"\n"+
            "Nota 2: "+ nota2 + "\n"+
            "Média: "+ media,

            gui
            );
    }
}
