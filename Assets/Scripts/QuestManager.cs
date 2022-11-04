using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestManager : MonoBehaviour
{
	// TODO: Serialize this instead of public
	public Image[] questItems;
	public Color completedColor;

	public void FinishQuest(int questIndex)
	{
		questItems[questIndex].color = completedColor;
	}

}
