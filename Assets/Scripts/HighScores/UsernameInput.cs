using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UsernameInput : MonoBehaviour {

	public InputField usernameInput;
	public GameObject pleaseEnterUsername;

	void Start () {
		if (PlayerPrefs.HasKey ("PlayerUsername")) {
			usernameInput.text = PlayerPrefs.GetString ("PlayerUsername");
		}
	}

	void Update () {
		if (usernameInput.text != null && usernameInput.text != "") {
			PlayerPrefs.SetString ("PlayerUsername", usernameInput.text);
		}
	}

	public void CheckLoadLevel (int level) {
		if (PlayerPrefs.HasKey ("PlayerUsername")) {
			GameManager.instance.LoadLevel (level);
		} else {
			pleaseEnterUsername.SetActive (true);
		}
	}
}
