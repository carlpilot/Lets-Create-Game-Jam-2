using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterActivator : MonoBehaviour {

	public bool isOn = false;
	public Material onMaterial, offMaterial;
	public Teleporter[] connectedTeleporters;

	void Update () {

		if (Input.GetMouseButtonDown (0)) {
			RaycastHit hit;
			if (Physics.Raycast (Camera.main.transform.position, Camera.main.transform.forward, out hit, 5f)) {
				if (hit.transform == transform) {
					// Hit this TeleporterActivator
					isOn = !isOn;
				}
			}
		}

		SetMaterial (isOn ? onMaterial : offMaterial, 1);
		foreach (Teleporter t in connectedTeleporters) {
			t.teleporterActive = isOn;
		}
	}

	void SetMaterial (Material m, int place) {
		Material[] materials = GetComponent<Renderer> ().materials;
		materials [place] = m;
		GetComponent<Renderer> ().materials = materials;
		materials = null;
	}
}
