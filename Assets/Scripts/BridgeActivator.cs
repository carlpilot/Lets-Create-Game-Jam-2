using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeActivator : MonoBehaviour {

	public bool isOn = false;

	public void SetMaterial (Material m) {
		GetComponent<MeshRenderer> ().material = m;
	}
}
