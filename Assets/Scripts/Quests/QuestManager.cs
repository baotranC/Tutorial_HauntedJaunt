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
	public static Color COMPLETED_COLOR = Color.green;

	private ExitQuest questEscape;
	// private Quest questRooms;
	private SneakOnEnemiesQuest questEnemies;
	private FetchCollectablesQuest questStars;

	public List<Quest> Quests { get; private set; }

	public void OnDisable()
	{
		questEnemies.Disable();
		questEscape.Disable();
		questStars.Disable();
	}

	private void Start()
	{
		// questEscape = new ExitQuest(questItems[0], 0, true, "Escape", "Escape the mansion", 1);
		questEscape = new ExitQuest(questItems[0], 0, true, "Escape", "Find escape", 1);
		questStars = new FetchCollectablesQuest(questItems[1], 3, true, "Stars", "Fetch " + 3 + " stars", 3, "Star");
		questEnemies = new SneakOnEnemiesQuest(questItems[2], 2, false, "Enemies", "Approach without being noticed by " + 3 + " different enemies", 3);
		// questRooms = new Quest(1, false, "Rooms", "Visit at least " + 5 + " rooms", 5);
		Quests = new List<Quest>() { questEscape, questStars, questEnemies };

		questEscape.Enable();
		questStars.Enable();
		questEnemies.Enable();
	}
}
