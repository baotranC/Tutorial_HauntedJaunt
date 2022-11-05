using UnityEngine;
using UnityEngine.UI;

public class ExitQuest : Quest
{
	public ExitQuest(Image questItem, int id, bool isMainQuest, string name,
	string description, int nbTasksToComplete) : base(questItem, id, isMainQuest, name, description, nbTasksToComplete)
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
		if (!IsCompleted)
		{
			IncrementTaskCompleted();
			if (IsCompleted)
			{
				QuestItem.color = QuestManager.COMPLETED_COLOR;
			}
		}
	}
}