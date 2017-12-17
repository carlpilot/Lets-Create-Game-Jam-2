using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockLevelButtons : MonoBehaviour {

	public GameObject lockIcon;
	public int level;

	void Start () {
		if (PlayerPrefs.HasKey ("HasWonLevel" + (level - 1))) {
			if (PlayerPrefs.GetInt ("HasWonLevel" + (level - 1)) == 1) {
				lockIcon.SetActive (false);
			} else {
				lockIcon.SetActive (true);
			}
		} else {
			lockIcon.SetActive (true);
		}
	}
}
