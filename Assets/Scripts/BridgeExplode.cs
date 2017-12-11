using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeExplode : MonoBehaviour {

	public Part[] parts;
	public float maxRandomExplodeDistance = 50f;
	public float collapseTime = 5f;

	void Start () {
		Collapse ();
	}

	[ContextMenu("Set Pieces to Children")]
	public void SetPiecesToChildren () {
		parts = new Part[transform.childCount];

		for (int i = 0; i < transform.childCount; i++) {
			parts [i] = new Part (transform.GetChild (i).gameObject, transform.GetChild (i).position, transform.GetChild (i).position);
		}
	}

	[ContextMenu("Set Current Positions as Targets")]
	public void SetTargetPositionsToCurrentPositions () {
		for (int i = 0; i < parts.Length; i++) {
			parts [i].targetPosition = parts [i].go.transform.position;
		}
	}

	[ContextMenu("Set Current Positions as Explodeds")]
	public void SetExplodedPositionsToCurrentPositions () {
		for (int i = 0; i < parts.Length; i++) {
			parts [i].explodedPosition = parts [i].go.transform.position;
		}
	}

	[ContextMenu("Random Explode")]
	public void RandomExplode () {
		for (int i = 0; i < parts.Length; i++) {
			//parts [i].go.transform.localPosition *= Random.Range (maxRandomExplodeDistance / 2f, maxRandomExplodeDistance);
			parts[i].go.transform.localPosition += Random.insideUnitSphere * maxRandomExplodeDistance;
		}
	}

	[ContextMenu("To Target Positions")]
	public void ToTargetPositions () {
		for (int i = 0; i < parts.Length; i++) {
			parts [i].go.transform.position = parts [i].targetPosition;
		}
	}

	[ContextMenu("To Exploded Positions")]
	public void ToExplodedPositions () {
		for (int i = 0; i < parts.Length; i++) {
			parts [i].go.transform.position = parts [i].explodedPosition;
		}
	}
		
	public void Collapse () {
		StartCoroutine (CollapseBridge ());
	}
	IEnumerator CollapseBridge () {
		int numSteps = Mathf.RoundToInt (collapseTime / Time.deltaTime);
		for (int i = 0; i < numSteps; i++) {
			for (int j = 0; i < parts.Length; j++) {
				parts [j].go.transform.position = Vector3.Lerp (parts [j].explodedPosition, parts [j].targetPosition, (float)i / (float)numSteps);
			}
			yield return new WaitForEndOfFrame();
		}
	}

	public struct Part {
		public GameObject go;
		public Vector3 targetPosition;
		public Vector3 explodedPosition;
		public Part (GameObject go, Vector3 targetPosition, Vector3 explodedPosition)
		{
			this.go = go;
			this.targetPosition = targetPosition;
			this.explodedPosition = explodedPosition;
		}
	}
}
