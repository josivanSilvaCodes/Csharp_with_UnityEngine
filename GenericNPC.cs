using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericNPC
{

	private float x;
	private float y;
	private float dx;
	private float dy;
	private float size;
	private Color c;


	public float GetX(){ return x;}
	public void SetX(float _x){x = _x;}

	public float GetY(){ return y;}
	public void SetY(float _y){y = _y;}

	public float GetDX(){ return x;}
	public void SetDX(float _x){y = _x;}

	public float GetDY(){ return y;}
	public void SetDY(float _y){y = _y;}

	public float GetSize(){ return size;}
	public void SetSize(float _sz){size = _sz;}

	public Color GetColor(){ return c;}
	public void SetColor(Color _c){ c = _c;}
}

