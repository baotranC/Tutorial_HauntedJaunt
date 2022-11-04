using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollectableController : MonoBehaviour
{
	private void OnTriggerEnter(Collider collision) {
		if(collision.tag == "Player"){
			QuestManager.Instance.AddCollectables(gameObject.tag);
			Destroy(gameObject);
		}
	}
}
