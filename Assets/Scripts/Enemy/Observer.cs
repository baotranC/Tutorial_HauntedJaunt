using UnityEngine;

public class Observer : MonoBehaviour
{
	[SerializeField]
	private Transform player;
	[SerializeField]
	private GameEnding gameEnding;

	bool m_IsPlayerInRange;

	void OnTriggerEnter(Collider collider)
	{
		if (collider.transform == player)
		{
			m_IsPlayerInRange = true;
		}
	}

	void OnTriggerExit(Collider collider)
	{
		if (collider.transform == player)
		{
			m_IsPlayerInRange = false;
		}
	}

	void Update()
	{
		if (m_IsPlayerInRange)
		{
			Vector3 direction = player.position - transform.position + Vector3.up;
			Ray ray = new Ray(transform.position, direction);
			RaycastHit raycastHit;

			if (Physics.Raycast(ray, out raycastHit))
			{
				if (raycastHit.collider.transform == player)
				{
					gameEnding.CaughtPlayer();
				}
			}
		}
	}
}
