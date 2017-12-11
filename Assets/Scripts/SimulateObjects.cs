using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SimulateObjects : MonoBehaviour {

	static int maxIterations = 1000;
	SimulatedBody[] simulatedBodies;

	[ContextMenu("Run Simulation")]
	public void Simulate () {

		Physics.autoSimulation = false;

		simulatedBodies = FindObjectsOfType<Rigidbody> ().Select (rb => new SimulatedBody (rb, rb.transform.IsChildOf (this.transform))).ToArray ();
		for (int i = 0; i < maxIterations; i++) {
			Physics.Simulate (Time.fixedDeltaTime);
			if (simulatedBodies.All (body => body.rigidbody.IsSleeping ())) {
				print (i);
				break;
			}
		}

		Physics.autoSimulation = true;

		foreach (SimulatedBody body in simulatedBodies) {
			if (!body.isChild) {
				body.Reset ();
			}
		}
	}

	[ContextMenu("Reset Simulation")]
	public void ResetAllBodies () {
		if (simulatedBodies != null) {
			foreach (SimulatedBody body in simulatedBodies) {
				body.Reset ();
			}
		}
	}

	struct SimulatedBody {
		public readonly Rigidbody rigidbody;
		public readonly bool isChild;
		readonly Vector3 originalPosition;
		readonly Quaternion originalRotation;
		readonly Transform transform;

		public SimulatedBody (Rigidbody rigidbody, bool isChild) {
			this.rigidbody = rigidbody;
			this.isChild = isChild;
			transform = rigidbody.transform;
			originalPosition = transform.position;
			originalRotation = transform.rotation;
		}

		public void Reset () {
			transform.position = originalPosition;
			transform.rotation = originalRotation;
			if (rigidbody != null) {
				rigidbody.velocity = Vector3.zero;
				rigidbody.angularVelocity = Vector3.zero;
			}
		}
	}
}
