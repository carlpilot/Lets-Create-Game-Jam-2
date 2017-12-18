using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlayMenu : MonoBehaviour {

	public GameObject menu;

	public void Toggle () {
		menu.SetActive (!menu.activeSelf);
	}
}
