using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreDisplay : MonoBehaviour {

	public GameObject scoreItemPrefab;
	public GameObject scrollViewContent;

	public void ShowScores (WWW www) {
		StartCoroutine (showScores (www));
	}

	IEnumerator showScores (WWW www) {
		while (!www.isDone) {
			yield return null;
		}
		//print (www.text);
		StartCoroutine (showScores (new WWW (www.url)));
	}
}
