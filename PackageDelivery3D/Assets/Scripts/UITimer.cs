using UnityEngine;
using TMPro; 

public class UITimer : MonoBehaviour
{
	[Tooltip("Timer in Seconds")]
	[SerializeField] private float timerSeconds = 60f;

	[SerializeField] private TextMeshProUGUI timerText;

	private bool isTimerActive = false;

	private void Awake()
	{
		timerText = GetComponentInChildren<TextMeshProUGUI>();
		isTimerActive = true;
	}

	private void Update()
	{
		CountDown();
	}

	/// <summary>
	/// Counts down the timer with Time.deltaTime.
	/// </summary>
	private void CountDown()
	{
		timerSeconds -= Time.deltaTime;
		if (timerSeconds > 0 && isTimerActive == true)
		{
			UpdateLevelTimer(timerSeconds);
		}
		else if(timerSeconds <= 0 && isTimerActive == true)
		{
			Debug.Log("Timer over");
		}
	}

	/// <summary>
	/// Small Calculation for the timer to be "00:00" when counting down.
	/// </summary>
	/// <param name="timerCounter"></param>
	private void UpdateLevelTimer(float timerCounter)
	{
		int minutes = Mathf.FloorToInt(timerCounter / 60f);
		int seconds = Mathf.RoundToInt(timerCounter % 60f);
		string formatedSeconds = seconds.ToString();

		if (seconds == 60)
		{
			seconds = 0;
			minutes += 1;
		}

		timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
	}

	private void StopTimer()
	{
		isTimerActive = false;
	}

	private void OnEnable()
	{
		FinishLine.finishEvent += StopTimer;
	}

	private void OnDisable()
	{
		FinishLine.finishEvent -= StopTimer;
	}
}