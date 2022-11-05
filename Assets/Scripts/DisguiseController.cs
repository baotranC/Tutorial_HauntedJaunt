using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DisguiseController : MonoBehaviour
{
	public delegate void OnDisguiseMode(bool isDisguise);
	public static OnDisguiseMode onDisguiseMode;

	private void OnTriggerEnter(Collider collision)
	{
		if (collision.tag == "Player")
		{
			onDisguiseMode(true);
			// SwapPlayerController.SwapObjects();
			// onFetchCollectable(gameObject.tag);
			Destroy(gameObject);
		}
	}
}
