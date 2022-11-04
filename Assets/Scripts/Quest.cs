using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Add audio
public class Quest
{
	public int Id { get; }
	public bool IsPrimaryQuest { get; }
	public string Name { get; }
	public string Description { get; }
	public int NbTasksToComplete { get; }
	public int NbTasksCompleted { get; private set; }
	public bool IsCompleted { get; private set; }

	public Quest(int id, bool isPrimaryQuest, string name,
	string description, int nbTasksToComplete)
	{
		Id = id;
		IsPrimaryQuest = isPrimaryQuest;
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
