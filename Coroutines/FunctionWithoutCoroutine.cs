using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class FunctionWithoutCoroutine.cs : MonoBehaviour
{
    void Start()
    {
        Esperar();
        Debug.Log("Tarefa importante");
    }

    void Esperar()
    {
        System.Threading.Thread.Sleep(TimeSpan.FromSeconds(6));
        Debug.Log("Esperou 6 segundos");
        System.Threading.Thread.Sleep(TimeSpan.FromSeconds(4));
        Debug.Log("Esperou 4 segundos");
    }
}
