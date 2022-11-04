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

	private Quest questEscape;
	private Quest questRooms;
	private SneakOnEnemiesQuest questEnemies;
	private FetchCollectablesQuest questStars;

	public void OnDisable()
	{
		questEnemies.Disable();
		questStars.Disable();
	}

	private void Start()
	{
		// questEscape = new Quest(0, true, "Escape", "Escape the mansion", 1);
		// questRooms = new Quest(1, false, "Rooms", "Visit at least " + 5 + " rooms", 5);
		questEnemies = new SneakOnEnemiesQuest(questItems[2], 2, false, "Enemies", "Approach without being noticed by " + 3 + " different enemies", 3);
		questStars = new FetchCollectablesQuest(questItems[3], 3, false, "Stars", "Fetch " + 3 + " stars", 3, "Star");
		
		questEnemies.Enable();
		questStars.Enable();
	}
}
