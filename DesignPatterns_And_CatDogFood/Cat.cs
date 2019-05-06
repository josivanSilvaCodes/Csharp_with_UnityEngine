using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat: MonoBehaviour
{
	[SerializeField]
	public GameObject shape;

	public void Draw()
	{
		shape.GetComponent<FacadeShape> ().criarQuad (transform.position.x, transform.position.y, 10, new Color (200, 0, 0));
	}

}















/*
 private QuadShape qs;

	public void Draw()
	{
		qs = new QuadShape ();
		qs.c = Color.red;
		qs.px = 20;
		qs.py = 30;
		qs.size = 10;
		qs.DrawShape ();
	}
*/