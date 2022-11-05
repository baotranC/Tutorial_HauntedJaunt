using UnityEngine;
using System.Collections;

public class SwapPlayerController : MonoBehaviour
{
	[SerializeField]
	private GameObject humanPlayer;
	[SerializeField]
	private GameObject tombstonePlayer;

	private void Start()
	{
		tombstonePlayer.SetActive(false);
	}

	public void OnEnable()
	{
		DisguiseController.onDisguiseMode += SwapObjects;
	}

	public void OnDisable()
	{
		DisguiseController.onDisguiseMode -= SwapObjects;
	}

	public void SwapObjects(bool isDisguise)
	{
		StartCoroutine(DisguiseCoutine(4f));
	}

	IEnumerator DisguiseCoutine(float time)
	{	
		// Swap tombstonePlayer	
		Vector3 currentPosition = humanPlayer.transform.position;
		humanPlayer.SetActive(false);		
		tombstonePlayer.SetActive(true);
		tombstonePlayer.transform.position = currentPosition;
		yield return new WaitForSeconds(time);
		// Swap humanPlayer
		currentPosition = tombstonePlayer.transform.position;
		tombstonePlayer.SetActive(false);		
		humanPlayer.SetActive(true);
		humanPlayer.transform.position = currentPosition;
	}
}
