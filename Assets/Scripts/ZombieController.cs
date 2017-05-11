using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour {

	Rigidbody rb;
	void Awake () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col){
		if (col.CompareTag ("Player")) {
			rb.AddForce (Vector3.forward * 900 + Vector3.up * 500 + Random.Range (-200f, 200f) * Vector3.right);
			rb.AddTorque (Vector3.right * 500000 + Vector3.forward * 5000);
		}
	}
}
