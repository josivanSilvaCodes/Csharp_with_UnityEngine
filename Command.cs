using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//The parent class
public abstract class Command
{
	//How far should the box move when we press a button
	protected float moveDistance = 1f;

	//Move and maybe save command
	public abstract void Execute(Transform elementTrans, Command command);

	//Move the box
	public virtual void Move(Transform elementTrans) { }
}


//
// Child classes
//

public class MoveUp : Command
{
	//Called when we press a key
	public override void Execute(Transform elementTrans, Command command)
	{
		//Move the box
		Move(elementTrans);

		//Save the command
		CommandInput.oldCommands.Add(command);
	}

	//Move the box
	public override void Move(Transform elementTrans)
	{
		elementTrans.Translate(-elementTrans.up * moveDistance);
	}
}


public class MoveDown : Command
{
	//Called when we press a key
	public override void Execute(Transform elementTrans, Command command)
	{
		//Move the box
		Move(elementTrans);

		//Save the command
		CommandInput.oldCommands.Add(command);
	}

	//Move the box
	public override void Move(Transform elementTrans)
	{
		elementTrans.Translate(elementTrans.up * moveDistance);
	}
}


public class MoveLeft : Command
{
	//Called when we press a key
	public override void Execute(Transform elementTrans, Command command)
	{
		//Move the box
		Move(elementTrans);

		//Save the command
		CommandInput.oldCommands.Add(command);
	}

	//Move the box
	public override void Move(Transform elementTrans)
	{
		elementTrans.Translate(-elementTrans.right * moveDistance);
	}
}


public class MoveRight : Command
{
	//Called when we press a key
	public override void Execute(Transform elementTrans, Command command)
	{
		//Move the box
		Move(elementTrans);

		//Save the command
		CommandInput.oldCommands.Add(command);
	}

	//Move the box
	public override void Move(Transform elementTrans)
	{
		elementTrans.Translate(elementTrans.right * moveDistance);
	}
}


//For keys with no binding
public class DoNothing : Command
{
	//Called when we press a key
	public override void Execute(Transform boxTrans, Command command)
	{
		//Nothing will happen if we press this key
	}
}