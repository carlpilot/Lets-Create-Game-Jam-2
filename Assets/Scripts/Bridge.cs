using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour {

	public BridgeActivator[] activators;
	public bool isClosed;
	public Material plankMatClosed, plankMatOpen;
	public Transform plankParent;
	public Transform[] bridgeSegments;

	void Update () {

		bool allActivatorsOn = true;
		foreach (BridgeActivator a in activators) {
			if (!a.isOn) {
				allActivatorsOn = false;
				break;
			}
		}

		isClosed = allActivatorsOn;

		if (plankParent != null) {
			foreach (MeshRenderer mr in plankParent.GetComponentsInChildren<MeshRenderer>()) {
				mr.material = isClosed ? plankMatClosed : plankMatOpen;
				mr.GetComponent<Collider> ().enabled = isClosed;
			}
		}
		foreach (Transform t in bridgeSegments) {
			foreach (MeshRenderer mr in t.GetComponentsInChildren<MeshRenderer>()) {
				mr.material = isClosed ? plankMatClosed : plankMatOpen;
				mr.GetComponent<Collider> ().enabled = isClosed;
			}
		}
	}
}
