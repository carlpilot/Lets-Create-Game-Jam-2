using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

	public GameObject teleporter;
	Vector3 lastPosition;

	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			RaycastHit hit;
			Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
			if (Physics.Raycast (ray, out hit)) {
				if (hit.transform.tag == "Teleporter") {
					lastPosition = transform.position;

					if (Vector3.Distance (transform.position, hit.transform.position) > 10f) {
						if (hit.transform.GetComponent<Teleporter> ().teleporterActive) {
							transform.position = hit.transform.position + Vector3.up;
							GetComponent<Rigidbody> ().velocity = Vector3.zero; // To prevent fall-dying from teleportation
						} else {
							print ("Teleporter inactive");
						}
					} else {
						print ("Teleporter too close");
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
				} else {
					//print ("Hit is not teleporter. Hit is: " + hit.transform.gameObject.name);
				}
			}
		}
	}
}
