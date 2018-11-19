using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : GenericNPC
{
	
	public GameObject shape;

	public Dog(GameObject _shape) 
	{
		shape = _shape;
		GameManager.singleManager.changeScore (2);
	}

	public void Draw()
	{
		shape.GetComponent<FacadeShape> ().criarRect (this.GetX(), this.GetY(), this.GetSize(), new Color (0, 0, 200));
	}



}
