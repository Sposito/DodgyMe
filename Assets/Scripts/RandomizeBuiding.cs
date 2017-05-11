using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeBuiding : MonoBehaviour {

	// Use this for initialization
	void Start () {
		float height = Random.Range (1f, 7f);
		transform.localScale = new Vector3 (transform.localScale.x, transform.localScale.y * height, transform.localScale.z);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
