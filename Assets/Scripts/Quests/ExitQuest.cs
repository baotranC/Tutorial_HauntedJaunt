using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ExitQuest : Quest
{
	public delegate void OnEndGame();
	public static OnEndGame onEndGame;

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
		// Find Escape
		if (!IsCompleted)
		{
			IncrementTaskCompleted();
			if (IsCompleted)
			{
				QuestItem.color = QuestManager.COMPLETED_COLOR;
			}
		}

		bool areMainQuestsCompleted = true;
		// Verify all primary quest are done
		List<Quest> quests = QuestManager.Instance.Quests;
		foreach (var quest in quests)
		{
			if (quest.IsMainQuest && !quest.IsCompleted)
			{
				areMainQuestsCompleted = false;
			}
		}

		if (areMainQuestsCompleted)
		{
			onEndGame();
		}
	}

}