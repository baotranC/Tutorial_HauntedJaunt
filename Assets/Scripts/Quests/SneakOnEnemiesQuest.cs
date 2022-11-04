using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SneakOnEnemiesQuest : Quest
{
	public SneakOnEnemiesQuest(Image questItem, int id, bool isPrimaryQuest, string name,
	string description, int nbTasksToComplete) : base(questItem, id, isPrimaryQuest, name, description, nbTasksToComplete)
	{
	}

	override public void Enable()
	{
		ProximityEnemyController.onSneakEnemy += AddEnemies;
	}

	override public void Disable()
	{
		ProximityEnemyController.onSneakEnemy -= AddEnemies;
	}

	public void AddEnemies()
	{
		IncrementTaskCompleted();
		if (IsCompleted)
		{
			QuestItem.color = QuestManager.COMPLETED_COLOR;
		}
	}
}