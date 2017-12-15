using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour {

	void OnTriggerEnter (Collider col) {
		if (col.tag == "Player") {
			GameManager.instance.WinGame ();
		}
	}
}
