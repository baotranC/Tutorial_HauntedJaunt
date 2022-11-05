using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
	[SerializeField]
	private GameObject HUD;

	private bool m_isActive = true;

	private void Update()
	{
		if (Input.GetButtonDown("RemoveHUD"))
		{
			if (m_isActive)
			{
				setVisibleHUD(false);
			}
			else
			{
				setVisibleHUD(true);
			}
		}
	}

	public static void setVisibleHUD(bool isVisible)
	{
		HUD.SetActive(isVisible);
		m_isActive = isVisible;
	}
}
