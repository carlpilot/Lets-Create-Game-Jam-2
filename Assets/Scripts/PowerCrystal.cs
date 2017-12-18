using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerCrystal : MonoBehaviour {

	public bool startsOn = false;
	public bool isOn = false;
	public Material off, on;
	public BridgeActivator[] connectedActivators;

	void Start () {
		isOn = startsOn;
	}

	void Update () {

		if (Input.GetMouseButtonDown (0)) {
			RaycastHit hit;
			if (Physics.Raycast (Camera.main.transform.position, Camera.main.transform.forward, out hit, 10f)) {
				if (hit.transform.position.Equals (this.transform.position)) { // transform.position is somehow more accurate than checking transforms
					// hit is this gameobject
					Toggle ();
				}
			}
		}

		// Apparently you can't set materials directly in the renderer array
		Material[] materials = GetComponent<MeshRenderer> ().materials;
		materials [1] = isOn ? on : off;
		GetComponent<MeshRenderer> ().materials = materials;
		materials = null; // to not use up too much memory

		foreach (BridgeActivator ba in connectedActivators) {
			ba.isOn = isOn;
			ba.SetMaterial (isOn ? on : off);
		}
	}

	public void Toggle () {
		isOn = !isOn;
		GetComponent<AudioSource> ().Play ();
	}
}
