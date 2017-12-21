using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugTools : MonoBehaviour {

	public float numLevels = 4;

	[ContextMenu("Clear All High Scores")]
	void ClearAllHighScores () {
		for(int i = 1; i <= numLevels; i++) {
			HighScores.Clear (i);
		}
	}
}
