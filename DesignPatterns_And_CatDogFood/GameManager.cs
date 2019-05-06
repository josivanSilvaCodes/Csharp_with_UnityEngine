using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour 
{
	public static GameManager singleManager;
	private int score = 0;

	[SerializeField]
	public Cat gato;

	[SerializeField]
	public GameObject shape;

	Food comida;
	Dog[] cachorros;

	void Start()
	{
		singleManager = this;
		score = 0;

		comida = new Food(shape);
		cachorros = new Dog[20];

		for(int i = 0; i < cachorros.Length; i++)
		{
			int lx =  Random.Range(20, 620);
			int ly =  Random.Range(20, 200);

			cachorros [i] = new Dog(shape);
			cachorros [i].SetX (lx);
			cachorros [i].SetY (ly);
			cachorros [i].SetSize (10);
			//Debug.Log ("cachorros [i]: " + cachorros [i].GetX() + ", " + cachorros [i].GetY() );
		}

		int fx =  Random.Range(220, 620);
		int fy =  Random.Range(20, 280);
		comida.SetX (fx);
		comida.SetY (fy);
		comida.SetSize (0.025f);

	}

	void FixedUpdate ()
	{

	}

	public void changeScore(int s)
	{
		if (score < 0) 
		{
			score = 0;
		} 
		else if (score > 60) 
		{
			score = 60;
		} 
		else 
		{
			score = score + s;
		}
	}

	void OnGUI()
	{
		GUI.Label (new Rect (30, 50, 100, 100), "score: " + score);
		gato.Draw ();
		comida.Draw ();
		for(int i = 0; i < cachorros.Length; i++)
		{
			if (cachorros [i] != null) 
			{
				cachorros [i].Draw ();
			}
		}


	}
}
