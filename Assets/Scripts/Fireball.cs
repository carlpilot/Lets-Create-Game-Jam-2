using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {

	public static float explosionRadius = 25f;
	public static float explosionForce = 5000f;

	void OnCollisionEnter (Collision col) {
		Explode ();
	}

	void Explode () {
		foreach (Collider col in Physics.OverlapSphere(transform.position, explosionRadius)) {
			if (col.GetComponent<Rigidbody> () != null) {
				col.GetComponent<Rigidbody> ().AddExplosionForce (explosionForce, transform.position, explosionRadius);
			}
		}
		GetComponent<AudioSource> ().Play ();
		GetComponent<MeshRenderer> ().enabled = false;
		GetComponent<Collider> ().enabled = false;
		Destroy (GetComponent<Rigidbody> ());
		Destroy (GetComponent<ParticleSystem> ());
		GetComponentInChildren<ParticleSystem> ().Play ();

		float timeToDestroy = (GetComponentInChildren<ParticleSystem> ().main.duration > GetComponent<AudioSource> ().clip.length) ? GetComponentInChildren<ParticleSystem> ().main.duration : GetComponent<AudioSource> ().clip.length;
		Destroy (this.gameObject, timeToDestroy);
	}
}
