using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food 
{
    public Color c;
    public float px;
    public float py;
    public int size;

    public void Draw(float _x, float _y, int _sz, Color _c)
    {
        c = _c;
        px = _x;
        py = _y;
        size = _sz;


        GUI.backgroundColor = c;
        GUI.Box(new Rect(px, py, size, size), GUIContent.none);

    }


    public void Move(int v)
    {
        px = px + v;
    }
}
