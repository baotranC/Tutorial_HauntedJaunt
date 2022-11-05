using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
	[SerializeField]
	private float fadeDuration = 1f;
	[SerializeField]
	private float displayImageDuration = 1f;
	[SerializeField]
	private GameObject player;
	[SerializeField]
	private CanvasGroup exitBackgroundImageCanvasGroup;
	[SerializeField]
	private AudioSource exitAudio;
	[SerializeField]
	private CanvasGroup caughtBackgroundImageCanvasGroup;
	[SerializeField]
	private AudioSource caughtAudio;

	bool m_IsPlayerAtExit;
	bool m_IsPlayerCaught;
	bool m_IsGameEnding;

	float m_Timer;
	bool m_HasAudioPlayed;

	public delegate void OnExit();
	public static OnExit onExit;

	public void OnEnable()
	{
		ExitQuest.onEndGame += endLevel;
	}

	public void OnDisable()
	{
		ExitQuest.onEndGame -= endLevel;
	}


	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			m_IsPlayerAtExit = true;
		}
	}

	public void CaughtPlayer()
	{
		m_IsPlayerCaught = true;
	}

	void Update()
	{
		if (m_IsPlayerAtExit)
		{
			m_IsPlayerAtExit = !m_IsPlayerAtExit;
			onExit();
		}
		else if (m_IsPlayerCaught)
		{
			ManageEndGame(caughtBackgroundImageCanvasGroup, false, caughtAudio);
		}
		else if (m_IsGameEnding)
		{
			ManageEndGame(exitBackgroundImageCanvasGroup, false, exitAudio);
		}
	}

	void ManageEndGame(CanvasGroup imageCanvasGroup, bool doRestart, AudioSource audioSource)
	{
		if (!m_HasAudioPlayed)
		{
			audioSource.Play();
			m_HasAudioPlayed = true;
		}

		m_Timer += Time.deltaTime;
		imageCanvasGroup.alpha = m_Timer / fadeDuration;

		if (m_Timer > fadeDuration + displayImageDuration)
		{
			if (doRestart)
			{
				SceneManager.LoadScene(0);
			}
			else
			{
				Debug.Log("Quit");
				// Application.Quit();
			}
		}
	}

	private void endLevel()
	{
		m_IsGameEnding = true;
	}
}
