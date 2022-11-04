using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollectableController : MonoBehaviour
{
    public delegate void OnFetchCollectable(string collectableType);
	public static OnFetchCollectable onFetchCollectable;

	private void OnTriggerEnter(Collider collision) {
		if(collision.tag == "Player"){
			onFetchCollectable(gameObject.tag);
			Destroy(gameObject);
		}
	}
}
