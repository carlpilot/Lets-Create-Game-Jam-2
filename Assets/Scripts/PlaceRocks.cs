using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceRocks : MonoBehaviour {

	public GameObject rock;
	public float numRocks;
	public float maxDistance;
	public SimulateObjects s;

	List<GameObject> rocks = new List<GameObject> (0);

	[ContextMenu("Place and Simulate")]
	public void PlaceAndSimulate () {
		if (rock == null || maxDistance == 0 || numRocks == 0 || s == null) {
			Debug.LogError ("Unable to place any rocks.");
			return;
		}
		for (int i = 0; i < numRocks; i++) {
			Vector2 random = Random.insideUnitCircle * maxDistance;
			Vector3 pos = new Vector3 (random.x, 50f, random.y);
			GameObject newRock = Instantiate (rock, pos, Quaternion.identity, s.transform) as GameObject;
			rocks.Add (newRock);
		}
		s.Simulate ();

		foreach (GameObject r in rocks) {
			if (r.transform.position.y < -50) {
				DestroyImmediate (r);
			}
		}
	}

	[ContextMenu("Remove Rocks")]
	public void ResetRocks () {
		foreach (GameObject r in rocks) {
			DestroyImmediate (r);
		}
		rocks = new List<GameObject> (0);
	}
}
