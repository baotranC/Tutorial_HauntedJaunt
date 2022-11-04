using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestManager : MonoBehaviour
{
	public static QuestManager Instance { get; private set; }
	protected virtual void Awake() => Instance = this as QuestManager;

	[SerializeField]
	private Image[] questItems;
	[SerializeField]
	private Color completedColor;

	private Quest questEscape;
	private Quest questRooms;
	private Quest questEnemies;
	private Quest questStars;

	private void Start()
	{
		questEscape = new Quest(0, true, "Escape", "Escape the mansion", 1);
		questRooms = new Quest(1, false, "Rooms", "Visit at least " + 5 + " rooms", 5);
		questEnemies = new Quest(2, false, "Enemies", "Approach without being noticed by " + 3 + " different enemies", 3);
		questStars = new Quest(3, false, "Stars", "Fetch " + 3 + " stars", 3);
	}

	public void AddCollectables(string collectableType)
	{
		if (collectableType.Equals("Star"))
		{
			questStars.IncrementTaskCompleted();
			if (questStars.IsCompleted)
			{
				questItems[questStars.Id].color = completedColor;
			}
		}
	}

}
