using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour {

	public Light light;
	public ParticleSystem particleSystem;
	public bool teleporterActive = true;
	public bool isLastPositionMarker = false;

	void Awake () {
		if (light == null) {
			light = GetComponentInChildren<Light> ();
			particleSystem = GetComponent<ParticleSystem> ();
		}
	}

	void Update () {
		if (teleporterActive) {
			light.enabled = true;
			if (!particleSystem.isPlaying) {
				particleSystem.Play ();
			}
		} else {
			light.enabled = false;
			if (particleSystem.isPlaying) {
				particleSystem.Stop ();
			}
		}
	}
}
