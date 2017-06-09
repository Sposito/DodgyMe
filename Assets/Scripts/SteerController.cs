using UnityEngine;

public class SteerController : MonoBehaviour {
	
	Vector3 lastPos;
	Vector3 deltaPos;

	void Update () {
		deltaPos = lastPos - transform.position;
		lastPos = transform.position;
	}

	void OnDrawGizmosSelected() {
		Gizmos.color = Color.blue;
		Gizmos.DrawLine(transform.position, (transform.position + deltaPos.normalized) * 4);
	}
}
