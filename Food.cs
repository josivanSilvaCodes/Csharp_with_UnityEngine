using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : GenericNPC
{
	public GameObject shape;

	public Food(GameObject _shape) 
	{
		shape = _shape;
		GameManager.singleManager.changeScore (-3);
	}


	public void Draw () 
	{
		shape.GetComponent<FacadeShape> ().criarTriangle (this.GetX(), this.GetY(), this.GetSize(), new Color (0, 200, 0));
	}
}
