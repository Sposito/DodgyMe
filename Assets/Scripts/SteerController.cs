using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteerController : MonoBehaviour {
	
	Vector3 lastPos;
	Vector3 deltaPos;
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		deltaPos = lastPos - transform.position;

//		print (deltaPos.normalized);
		lastPos = transform.position;
//		print (deltaPos.x);
		//transform.rotation = Quaternion.FromToRotation (Vector3.forward, deltaPos.normalized);
	}

	void OnDrawGizmosSelected() {
		
		Gizmos.color = Color.blue;
		Gizmos.DrawLine(transform.position, (transform.position + deltaPos.normalized) * 4);


	}
}
