using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ExitQuest : Quest
{
	public ExitQuest(Image questItem, int id, bool isPrimaryQuest, string name,
	string description, int nbTasksToComplete) : base(questItem, id, isPrimaryQuest, name, description, nbTasksToComplete)
	{
	}

	override public void Enable()
	{
		GameEnding.onExit += showExit;
	}

	override public void Disable()
	{
		GameEnding.onExit -= showExit;
	}

	public void showExit()
	{
		Debug.Log("Exit time");
		HUDManager.setVisibleHUD(false);
		Application.Quit();
	}
}