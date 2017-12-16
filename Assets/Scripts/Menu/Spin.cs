using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour {

	public Vector3 axis = Vector3.up;
	public float revolutionTime;

	void Update () {
		transform.Rotate (axis, 360f * Time.deltaTime / revolutionTime);
	}
}
