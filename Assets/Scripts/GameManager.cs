using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager instance;
	GameObject player;
	public GameObject winMenu;
	public GameObject loseMenu;
	public UnityEngine.UI.Text nextLevelButtonTitle;

	void Start () {
		instance = this;
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	public void LoadLevel (int level) {
		SceneManager.LoadScene (level);
		// Build index correlates directly with level number: 0 = main menu, 1 = level 1, 2 = level 2 and so on
	}

	public void Reload () {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}

	public void MainMenu () {
		LoadLevel (0);
	}

	public void LevelSelection () {
		SceneManager.LoadScene ("levelselection");
	}

	public void Quit () {
		Application.Quit ();
	}

	public void NextLevel () {
		if (SceneManager.GetActiveScene ().buildIndex + 1 < SceneManager.sceneCountInBuildSettings) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
		} else {
			nextLevelButtonTitle.text = "This is the last level.";
		}
	}

	void Update () {
		if (SceneManager.GetActiveScene ().name.ToUpper ().Contains ("LEVEL")) {
			if (player.transform.position.y < -30f || player.transform.position.sqrMagnitude > 10000) {
				LoseGame ();
			}
		}
	}

	public void EndGame () {
		player.GetComponent<Rigidbody> ().isKinematic = true;
		Destroy (Camera.main.GetComponent<SimpleSmoothMouseLook> ()); // We don't want the mouse look going when you're clicking round the win menu
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}

	public void WinGame () {
		EndGame ();
		PlayerPrefs.SetInt ("HasWonLevel" + SceneManager.GetActiveScene ().buildIndex, 1);
		winMenu.SetActive (true);
	}

	public void LoseGame () {
		EndGame ();
		loseMenu.SetActive(true);
	}
}
