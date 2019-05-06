using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleShape : IImplementorElement 
{

	public Color c;
	public float px;
	public float py;
	public float size;

	public void DrawShape (float _x, float _y, float _sz, Color _c)
	{
		c = _c;
		px = _x;
		py = _y;
		size = _sz;

		GL.PushMatrix();
		GL.LoadOrtho();
		GL.Color (Color.blue);
		GL.Begin(GL.TRIANGLES);
		GL.Vertex3((px/620)-size, (py/280)-size, 0);
		GL.Vertex3((px/620), (py/280)+size, 0);
		GL.Vertex3((px/620)+size, (py/280)-size, 0);
		GL.End();
		GL.PopMatrix();
	}
}
