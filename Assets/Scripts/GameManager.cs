using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager instance;
	GameObject player;
	public GameObject winMenu;
	public GameObject loseMenu;

	void Start () {
		instance = this;
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	public static void LoadLevel (int level) {
		SceneManager.LoadScene (level);
		// Build index correlates directly with level number: 0 = main menu, 1 = level 1, 2 = level 2 and so on
	}

	public static void ReloadLevel () {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}

	public static void MainMenu () {
		LoadLevel (0);
	}

	public static void LevelSelection () {
		SceneManager.LoadScene ("levelselection");
	}

	void Update () {
		if (player.transform.position.y < -30f || player.transform.position.sqrMagnitude > 10000) {
			EndGame ();
		}
	}

	public void EndGame () {
		player.GetComponent<Rigidbody> ().isKinematic = true;
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}

	public void WinGame () {
		PlayerPrefs.SetInt ("HasWonLevel" + SceneManager.GetActiveScene ().buildIndex, 1);
	}
}
