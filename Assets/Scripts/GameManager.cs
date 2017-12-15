using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	GameObject player;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	public static void LoadLevel (int level) {
		SceneManager.LoadScene (level);
		// Build index correlates directly with level number: 0 = main menu, 1 = level 1, 2 = level 2 and so on
	}

	void Update () {
		if (player.transform.position.y < -30f || player.transform.position.sqrMagnitude > 10000) {
			EndGame ();
		}
	}

	void EndGame () {
		player.GetComponent<Rigidbody> ().isKinematic = true;
	}
}
