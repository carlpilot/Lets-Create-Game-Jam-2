using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public Text timerText;
	public float timerSpeed = 1.0f;
	public float time = 0.0f;

	void Update () {
		if (GameManager.instance.isRunning) {
			time += Time.deltaTime * timerSpeed;
		}
		timerText.text = Mathf.Round (time * 10f) / 10f + "";
	}
}
