using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour {

	void Update () {
		if (Vector3.Distance (transform.position, GameObject.FindGameObjectWithTag ("Player").transform.position) < 2.5f) {
			GameManager.instance.WinGame ();
		}
	}
}
