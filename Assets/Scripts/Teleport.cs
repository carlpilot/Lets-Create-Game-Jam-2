using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

	public GameObject teleporter;
	Vector3 lastPosition;

	void Start () {
		
	}

	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			RaycastHit hit;
			if (Physics.Raycast (Camera.main.transform.position, Camera.main.transform.forward, out hit)) {
				if (hit.transform.tag == "Teleporter") {
					lastPosition = transform.position;

					if (Vector3.Distance (transform.position, hit.transform.position) > 10f) {
						if (hit.transform.GetComponent<Teleporter> ().teleporterActive) {
							transform.position = hit.transform.position + Vector3.up;
						}
					}

					/*
					if (!hit.transform.GetComponent<Teleporter> ().isLastPositionMarker) {
						foreach (Teleporter t in FindObjectsOfType<Teleporter>()) {
							t.teleporterActive = false;
						}
						GameObject newTeleporter = Instantiate (teleporter, lastPosition, Quaternion.identity) as GameObject;
						newTeleporter.GetComponent<Teleporter>().isLastPositionMarker = true;
					} else {
						Destroy (hit.transform.gameObject);
					}
					*/
				}
			}
		}
	}
}
