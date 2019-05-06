using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandInput : MonoBehaviour 
{
	//The box we control with keys
	public Transform elementTrans;
	//The different keys we need
	private Command buttonW, buttonS, buttonA, buttonD, buttonB;
	//Stores all commands for replay and undo
	public static List<Command> oldCommands = new List<Command>();
	//Box start position to know where replay begins
	private Vector3 elementStartPos;


	void Start()
	{
		//Bind keys with commands
		buttonB = new DoNothing();
		buttonW = new MoveUp();
		buttonS = new MoveDown();
		buttonA = new MoveLeft();
		buttonD = new MoveRight();
	
		elementStartPos = elementTrans.position;
	}

	void Update()
	{

		HandleInput();
		oldCommands [(oldCommands.Count - 1)].Move (elementTrans);
	}


	//Check if we press a key, if so do what the key is binded to 
	public void HandleInput()
	{
		if (Input.GetKeyDown(KeyCode.A))
		{
			buttonA.Execute(elementTrans, buttonA);
		}
		else if (Input.GetKeyDown(KeyCode.B))
		{
			buttonB.Execute(elementTrans, buttonB);
		}
		else if (Input.GetKeyDown(KeyCode.D))
		{
			buttonD.Execute(elementTrans, buttonD);
		}
		else if (Input.GetKeyDown(KeyCode.S))
		{
			buttonS.Execute(elementTrans, buttonS);
		}
		else if (Input.GetKeyDown(KeyCode.W))
		{
			buttonW.Execute(elementTrans, buttonW);
		}

	}
}