using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

/* Add audio
 - Pick start
 - Task Completed
*/
public abstract class Quest
{
	public Image QuestItem { get; }
	public int Id { get; }
	public bool IsMainQuest { get; }
	public string Name { get; }
	public string Description { get; }
	public int NbTasksToComplete { get; }
	public int NbTasksCompleted { get; private set; }
	public bool IsCompleted { get; private set; }

	public abstract void Enable();
	public abstract void Disable();

	public Quest(Image questItem, int id, bool isMainQuest, string name,
	string description, int nbTasksToComplete)
	{
		QuestItem = questItem;
		Id = id;
		IsMainQuest = isMainQuest;
		Name = name;
		Description = description;
		NbTasksToComplete = nbTasksToComplete;
		NbTasksCompleted = 0;
		IsCompleted = false;
	}

	public void IncrementTaskCompleted()
	{
		NbTasksCompleted++;
		if (NbTasksCompleted >= NbTasksToComplete)
		{
			IsCompleted = true;
		}
	}
}
