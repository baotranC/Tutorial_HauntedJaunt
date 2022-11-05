using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TombMovement : MonoBehaviour
{
	[SerializeField]
	private float m_Speed = 0.05f;

	void FixedUpdate()
	{
		Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		gameObject.GetComponent<Rigidbody>().MovePosition(transform.position + m_Input * Time.deltaTime * m_Speed);
	}
}
