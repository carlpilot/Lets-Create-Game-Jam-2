using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScores : MonoBehaviour {

	public static void SaveScore (int level, string player, float time) {
		// Scores of 1 are used since time is the main scoring factors
		string url = "http://dreamlo.com/lb/" + SecretCode.Private (level) + "/add/" + WWW.EscapeURL (player) + "/1/" + time;
		WWW www = new WWW (url);
	}

	public static WWW GetScores (int level) {
		string url = "http://dreamlo.com/lb/" + SecretCode.Public (level) + "/pipe-seconds-asc/20";
		return new WWW (url);
	}

	public static WWW GetPlayerScore (int level, string player) {
		string url = "http://dreamlo.com/lb/" + SecretCode.Public (level) + "/pipe-get/" + WWW.EscapeURL (player);
		return new WWW (url);
	}
}
