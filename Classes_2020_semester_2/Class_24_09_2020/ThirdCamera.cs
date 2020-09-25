using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdCamera : ScriptableObject
{

    public float Y_ANGLE_MIN = 0.0f;
    public float Y_ANGLE_MAX = 20.0f;

    public Transform target; // transform do player (alvo)
    public Transform camTransform; // transform e position da camera 

    public float offset; // distância da camera ao player
    public float currentX;
    public float currentY;

    public void Init()
    {
        camTransform = Camera.main.transform;

        offset = 10.0f;
        currentX = 0;
        currentY = 0;
    }

    public void CamMove() // movimentação de câmera
    {
        currentX += Input.GetAxis("Mouse X");
        currentY += Input.GetAxis("Mouse Y");
        // limitar os angulos de visão com as constantes
        currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
    }

    public void CamLook() // olhar da câmera
    {
        Vector3 dir = new Vector3(0, 0, -offset);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        camTransform.position = target.position + rotation * dir;
        camTransform.LookAt(target.position);
    }
}
