using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScores : MonoBehaviour {

	public static void SaveScore (int level, string player, float time) {
		// Scores of 1 are used since time is the main scoring factors
		string url = "http://dreamlo.com/lb/" + SecretCode.Private (level) + "/add/" + WWW.EscapeURL (player) + "/" + (100000 - Mathf.RoundToInt(time * 100f));
		print (url);
		new WWW (url);
	}

	public static float ServerScoreToTime (float ss) {
		return (100000 - ss) / 1000f;
	}

	public static WWW GetScores (int level) {
		string url = "http://dreamlo.com/lb/" + SecretCode.Public (level) + "/pipe/100";
		return new WWW (url);
	}

	public static WWW GetPlayerScore (int level, string player) {
		string url = "http://dreamlo.com/lb/" + SecretCode.Public (level) + "/pipe-get/" + WWW.EscapeURL (player);
		return new WWW (url);
	}

	public static void Clear (int level) {
		string url = "http://dreamlo.com/lb/" + SecretCode.Private (level) + "/clear";
		new WWW (url);
	}

	public static float ScoreToTime (int score) {
		return (100000f - (float)score) / 100f;
	}
}
