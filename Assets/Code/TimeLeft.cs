using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Diagnostics;

public class TimeLeft : MonoBehaviour
{
	Text textField;
	Stopwatch stopWatch;
	bool started;

	// Use this for initialization
	void Start()
	{
		textField = GetComponent<Text>();
		stopWatch = new Stopwatch();
	}

	public void StartTimer()
	{
		stopWatch.Start();
	}

	// Update is called once per frame
	void Update()
	{
		if (stopWatch.IsRunning)
		{
			textField.text = "Time: " + (60000 - stopWatch.ElapsedMilliseconds);
		}
	}
}