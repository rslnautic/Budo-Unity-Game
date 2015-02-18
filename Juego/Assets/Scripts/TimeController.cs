using UnityEngine;
using System.Collections;

public class TimeController : MonoBehaviour {

	public float hitStopTime;

	static float hitStopTimer;
	static float hitStopTimerStop;

	public static void HitStop(){
		hitStopTimer = 0;
		hitStopTimerStop = Time.realtimeSinceStartup;
		Time.timeScale = 0;
	}

	void Update() {
		hitStopTimer = Time.realtimeSinceStartup;
		if ((hitStopTimer - hitStopTimerStop >= hitStopTime) && Time.timeScale < 1) {
			Time.timeScale = 1;
		}

	}
}
