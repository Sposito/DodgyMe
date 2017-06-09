using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour {

	Transform playerT;
	// Use this for initialization
	void Start () {
		playerT = GameObject.FindGameObjectWithTag ("Player").transform;
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt (playerT);
		if (transform.position.y >1f)
			Destroy(gameObject.GetComponent<LookAtPlayer>());
	}



}
