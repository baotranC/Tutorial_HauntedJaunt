using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
	[SerializeField]
	private float fadeDuration = 1f;
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
	[SerializeField]
	private float displayImageDuration = 1f;

	public delegate void OnExit();
	public static OnExit onExit;


	bool m_IsPlayerAtExit;
	float m_Timer;
	bool m_IsPlayerCaught;
	bool m_HasAudioPlayed;

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject == player)
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
			EndLevel(exitBackgroundImageCanvasGroup, false, exitAudio);
		}
		else if (m_IsPlayerCaught)
		{
			EndLevel(caughtBackgroundImageCanvasGroup, true, caughtAudio);
		}
	}

	void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart, AudioSource audioSource)
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
				onExit();
			}
		}
	}
}
