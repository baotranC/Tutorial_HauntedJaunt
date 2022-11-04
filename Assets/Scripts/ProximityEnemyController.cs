using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ProximityEnemyController : MonoBehaviour
{
	[SerializeField]
	private string enemieTag;
	private List<int> m_enemiesInstanceId;

	public delegate void OnSneakEnemy();
	public static OnSneakEnemy onSneakEnemy;

	private void Start()
	{
		m_enemiesInstanceId = new List<int>();
	}
	public void OnTriggerEnter(Collider collider)
	{
		if (collider.transform.tag.Equals(enemieTag))
		{
			int instanceId = collider.gameObject.GetInstanceID();
			if (!m_enemiesInstanceId.Contains(instanceId))
			{
				m_enemiesInstanceId.Add(instanceId);
				onSneakEnemy();
			}
		}
	}
}
