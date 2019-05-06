ing System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class FunctionWithCoroutine : MonoBehaviour
{
    void Start()
    {
        StartCoroutine( Esperar() );
        Debug.Log("Tarefa importante");
    }

    IEnumerator Esperar()
    {
        yield return new WaitForSeconds(6);
        Debug.Log("Esperou 6 segundos");
        yield return new WaitForSeconds(4);
        Debug.Log("Esperou 4 segundos");
    }
}
