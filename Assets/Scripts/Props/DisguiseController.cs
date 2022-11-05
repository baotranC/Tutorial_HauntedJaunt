using UnityEngine;

public class DisguiseController : MonoBehaviour
{
	public delegate void OnDisguiseMode(bool isDisguise);
	public static OnDisguiseMode onDisguiseMode;

	private void OnTriggerEnter(Collider collision)
	{
		if (collision.tag == "Player")
		{
			onDisguiseMode(true);
			Destroy(gameObject);
		}
	}
}
