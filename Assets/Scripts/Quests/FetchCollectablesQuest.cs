using UnityEngine.UI;

public class FetchCollectablesQuest : Quest
{
	public string Type { get; }

	public FetchCollectablesQuest(Image questItem, int id, bool isMainQuest, string name,
	string description, int nbTasksToComplete, string type) : base(questItem, id, isMainQuest, name, description, nbTasksToComplete)
	{
		Type = type;
	}

	override public void Enable()
	{
		CollectableController.onFetchCollectable += AddCollectables;
	}

	override public void Disable()
	{
		CollectableController.onFetchCollectable -= AddCollectables;
	}

	public void AddCollectables(string collectableType)
	{
		if (collectableType.Equals(Type))
		{
			IncrementTaskCompleted();
			if (IsCompleted)
			{
				QuestItem.color = QuestManager.COMPLETED_COLOR;
			}
		}
	}
}