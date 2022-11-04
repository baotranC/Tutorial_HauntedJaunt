using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestFetchItem : MonoBehaviour
{
	public GameObject questmanager;

	private void OnTriggerEnter(Collider collision) {
		if(collision.tag == "Player"){
			FinishQuest();
			Destroy(gameObject);
		}
	}

	private void FinishQuest() {
		// questItem.color = completedColor;
		QuestManager gameManager = questmanager.GetComponent<QuestManager>();
		gameManager.FinishQuest(3); // TODO Change this for const 
	}
}
