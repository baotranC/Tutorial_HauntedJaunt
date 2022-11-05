using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using TMPro;

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

	// Results
	[SerializeField]
	private GameObject resultsCanvas;

	[SerializeField]
	private TMP_Text textResults;


	bool m_IsPlayerAtExit;
	bool m_IsPlayerCaught;
	bool m_IsGameEnding;
	bool m_IsGameEnd;

	float m_Timer;
	bool m_HasAudioPlayed;

	public delegate void OnExit();
	public static OnExit onExit;

	private void Start()
	{
		resultsCanvas.SetActive(false);
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
			VerifyIfGameIsEnding();
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
				if (!m_IsGameEnd)
				{
					m_IsGameEnd = true;
					DisplayResult();
				}
			}
		}
	}

	private void VerifyIfGameIsEnding()
	{
		bool areMainQuestsCompleted = true;
		// Verify all primary quest are done
		List<Quest> quests = QuestManager.Instance.Quests;
		foreach (var quest in quests)
		{
			if (quest.IsMainQuest && !quest.IsCompleted)
			{
				areMainQuestsCompleted = false;
			}
		}

		if (areMainQuestsCompleted)
		{
			m_IsGameEnding = true;
		}
	}

	private void DisplayResult()
	{
		resultsCanvas.SetActive(true);

		List<Quest> quests = QuestManager.Instance.Quests;
		string resutls = "";
		int totalCompleted = 0;
		int totalToComplete = 0;
		foreach (var quest in quests)
		{
			resutls += quest.Name + ": " + quest.NbTasksCompleted + " / " + quest.NbTasksToComplete + "\n";
			totalCompleted += quest.NbTasksCompleted;
			totalToComplete += quest.NbTasksToComplete;
		}

		resutls += "\nTotal: " + totalCompleted + " / " + totalToComplete;
		textResults.text = resutls;
	}

	public void Quit()
	{
		Debug.Log("Quit");
		Application.Quit();
	}
}
