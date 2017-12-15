using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Text))]
public class WinLoseLevelTitle : MonoBehaviour {

	void Start () {
		GetComponent<Text> ().text = "Level " + SceneManager.GetActiveScene ().buildIndex;
	}
}
