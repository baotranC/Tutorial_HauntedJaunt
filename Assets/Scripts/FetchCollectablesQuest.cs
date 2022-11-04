using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class FetchCollectablesQuest : Quest
{
	public FetchCollectablesQuest(Image questItem, int id, bool isPrimaryQuest, string name,
	string description, int nbTasksToComplete) : base(questItem, id, isPrimaryQuest, name, description, nbTasksToComplete)
	{
		// base.super(questItem, id, isPrimaryQuest, name, description, nbTasksToComplete);
		// QuestItem = questItem;
		// Id = id;
		// IsPrimaryQuest = isPrimaryQuest;
		// Name = name;
		// Description = description;
		// NbTasksToComplete = nbTasksToComplete;
		// NbTasksCompleted = 0;
		// IsCompleted = false;
	}

	override public void Enable()
	{
		Debug.Log("OnEnable");
		CollectableController.onFetchCollectable += AddCollectables;
	}

	override public void Disable()
	{
		CollectableController.onFetchCollectable -= AddCollectables;
	}

	public void AddCollectables(string collectableType)
	{
		if (collectableType.Equals("Star"))
		{
			IncrementTaskCompleted();
			if (IsCompleted)
			{
				QuestItem.color = QuestManager.COMPLETED_COLOR;
			}
		}
	}

}