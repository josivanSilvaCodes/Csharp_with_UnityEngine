using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadShape : IImplementorElement 
{
	public Color c;
	public float px;
	public float py;
	public float size;

	void Start()
	{
		
	}

	public void DrawShape (float _x, float _y, float _sz, Color _c)
	{
		c = _c;
		px = _x;
		py = _y;
		size = _sz;

		Texture2D texture = new Texture2D(1, 1);
		texture.SetPixel(0,0, c);
		texture.Apply();
		GUI.skin.box.normal.background = texture;
		GUI.Box(new Rect(px, py, size, size), GUIContent.none);
	}

}