using UnityEngine;
using System.Collections;

// Originally by Sebastian Lague at:
// https://github.com/SebLague/Kinematic-Equation-Problems/blob/master/Kinematics%20problem%2002/Assets/Scripts/BallLauncher.cs

// Modified by Carlpilot for Let's Create Game Jam 2

public class BallLauncher : MonoBehaviour {

	public GameObject ballPrefab;
	Rigidbody ball;
	public Transform target;

	public float height = 25;
	float h;
	public float gravity = -18;
	public float minFrequency = 5f;
	public float maxFrequency = 12f;

	public bool usePresetGravity;
	public bool debugPath;
	public bool useGuardTowerHeight;

	void Start() {
		if (usePresetGravity) {
			Physics.gravity = gravity * Vector3.up;
		} else {
			gravity = Physics.gravity.y;
		}
		if (useGuardTowerHeight)
			h = (transform.position.y > target.position.y) ? 0f : transform.position.y - target.position.y;

		InvokeRepeating ("Launch", Random.Range (2f, minFrequency), Random.Range (minFrequency, maxFrequency));
	}

	void Update () {
		h = (transform.position.y > target.position.y) ? height : transform.position.y - target.position.y + 1f;
	}

	/*
	void Update() {
		if (Input.GetKeyDown (KeyCode.Return)) {
			Launch ();
		}

		if (debugPath) {
			DrawPath ();
		}
	}
	*/

	void Launch() {
		ball = Instantiate (ballPrefab, transform.position, ballPrefab.transform.rotation).GetComponent<Rigidbody> ();
		ball.useGravity = true;
		ball.velocity = CalculateLaunchData ().initialVelocity;

		GetComponent<AudioSource> ().Play ();
	}

	LaunchData CalculateLaunchData() {
		float displacementY = target.position.y - ball.position.y;
		Vector3 displacementXZ = new Vector3 (target.position.x - ball.position.x, 0, target.position.z - ball.position.z);
		float time = Mathf.Sqrt(-2*h/gravity) + Mathf.Sqrt(2*(displacementY - h)/gravity);
		Vector3 velocityY = Vector3.up * Mathf.Sqrt (-2 * gravity * h);
		Vector3 velocityXZ = displacementXZ / time;

		return new LaunchData(velocityXZ + velocityY * -Mathf.Sign(gravity), time);
	}

	void DrawPath() {

		if (ball == null) {
			return;
		}

		LaunchData launchData = CalculateLaunchData ();
		Vector3 previousDrawPoint = ball.position;

		int resolution = 30;
		for (int i = 1; i <= resolution; i++) {
			float simulationTime = i / (float)resolution * launchData.timeToTarget;
			Vector3 displacement = launchData.initialVelocity * simulationTime + Vector3.up *gravity * simulationTime * simulationTime / 2f;
			Vector3 drawPoint = ball.position + displacement;
			Debug.DrawLine (previousDrawPoint, drawPoint, Color.green);
			previousDrawPoint = drawPoint;
		}
	}

	struct LaunchData {
		public readonly Vector3 initialVelocity;
		public readonly float timeToTarget;

		public LaunchData (Vector3 initialVelocity, float timeToTarget)
		{
			this.initialVelocity = initialVelocity;
			this.timeToTarget = timeToTarget;
		}

	}
}