using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static void LoadLevel (int level) {
		SceneManager.LoadScene (level);
		// Build index correlates directly with level number: 0 = main menu, 1 = level 1, 2 = level 2 and so on
	}
}
