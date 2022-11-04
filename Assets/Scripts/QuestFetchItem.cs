using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestFetchItem : MonoBehaviour
{
	// TODO: Serialize this instead of public
	public Image questItem;
	public Color completedColor;

	private void OnTriggerEnter(Collider collision) {
		if(collision.tag == "Player"){
			FinishQuest();
			Destroy(gameObject);
		}
	}

	private void FinishQuest() {
		questItem.color = completedColor;
	}
}
