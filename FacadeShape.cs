using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacadeShape : MonoBehaviour 
{
	private static QuadShape qs;
	private RectShape rs;
	private TriangleShape ts;

	void Start()
	{
		qs = new QuadShape ();
		rs = new RectShape ();
		ts = new TriangleShape ();

	}

	public void criarQuad(float _x, float _y, float _sz, Color _c)
	{
		qs.DrawShape (_x, _y, _sz, _c);
	}

	public void criarRect(float _x, float _y, float _sz, Color _c)
	{
		rs.DrawShape (_x, _y, _sz, _c);
	}

	public void criarTriangle(float _x, float _y, float _sz, Color _c)
	{
		ts.DrawShape (_x, _y, _sz, _c);
	}

}
