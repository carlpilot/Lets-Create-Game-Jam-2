using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreDisplay : MonoBehaviour {

	public GameObject scoreItemPrefab;
	public GameObject scrollViewContent;

	public void ShowScores (WWW www) {
		print (www.text);
	}
}
