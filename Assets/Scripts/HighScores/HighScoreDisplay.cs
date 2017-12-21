using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreDisplay : MonoBehaviour {

	public GameObject scoreItemPrefab;
	public GameObject scrollViewContent;
	public GameObject yourScore;
	public Timer timer;

	public void ShowScores (WWW www) {
		StartCoroutine (showScores (www));
	}

	IEnumerator showScores (WWW www) {
		while (!www.isDone) {
			yield return null;
		}

		DisplayScores (www.text);

		yield return new WaitForSeconds (1f);

		StartCoroutine (showScores (new WWW (www.url)));
	}

	void DisplayScores (string input) {

		for (int i = 0; i < scrollViewContent.transform.childCount; i++) {
			Destroy (scrollViewContent.transform.GetChild (i).gameObject);
		}

		yourScore.transform.Find ("PlayerName").GetComponent<Text> ().text = PlayerPrefs.GetString ("PlayerUsername");
		yourScore.transform.Find ("Time").GetComponent<Text> ().text = timer.time + " sec";

		string[] items = input.Split ('\n');
		for (int i = 0; i < items.Length; i++) {
			if (items [i].Length > 2) {

				string[] subItems = items [i].Split ('|');

				if (subItems.Length > 2) {

					string username = subItems [0];
					int score = int.Parse (subItems [1]);
					float time = HighScores.ScoreToTime (score);

					float y = -(scoreItemPrefab.GetComponent<RectTransform> ().rect.height / 2f + i * scoreItemPrefab.GetComponent<RectTransform> ().rect.height);

					GameObject newItem = Instantiate (scoreItemPrefab);
					newItem.transform.SetParent (scrollViewContent.transform, false);
					newItem.GetComponent<RectTransform> ().anchoredPosition = new Vector3 (0f, y, 0f);

					newItem.transform.Find ("PlayerName").GetComponent<Text> ().text = username;
					newItem.transform.Find ("Time").GetComponent<Text> ().text = time + " sec";

				}

			}
		}
	}
}
