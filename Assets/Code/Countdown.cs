using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Diagnostics;
using System;

public class Countdown : MonoBehaviour
{
	[SerializeField]
	Text textField;
	Stopwatch stopWatch;
	TimeSpan countFrom;
	Action cb;

	// Use this for initialization
	void Start()
	{
		stopWatch = new Stopwatch();
	}

	public void StartCountdown(int hours, int minutes, int seconds, Action callback)
	{
		countFrom = new TimeSpan(hours, minutes, seconds);
		stopWatch = new Stopwatch();
		cb = callback;
		stopWatch.Start();
	}

	public string getText()
	{
		return textField.text;
	}

	public void setText(string newText)
	{
		textField.text = newText;
	}

	// Update is called once per frame
	void Update()
	{
		if (stopWatch.IsRunning)
		{
			// Get the elapsed time as a TimeSpan value.
			TimeSpan ts = countFrom - stopWatch.Elapsed;
			if (ts.TotalMilliseconds > 0)
			{
				string elapsedTime = String.Format("{0:0}:{1:00}.{2:00}", ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
				setText(elapsedTime);
			}
			else
			{
				cb();
				stopWatch.Stop();
				setText("0:00.00");
			}
		}
	}
}