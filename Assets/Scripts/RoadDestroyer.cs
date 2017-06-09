using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadDestroyer : MonoBehaviour {

	Transform player;
	public float thrshold = 10f;
	void Start () {
		
		player = GameObject.FindGameObjectWithTag ("Player").transform;


		StartCoroutine("CheckAndDestroy");
//		print (float.MaxValue);
	}
	IEnumerator CheckAndDestroy(){
		while (true) {
			if (player.position.z - transform.position.z > thrshold) {
				StopCoroutine ("CheckAndDestroy");
				GameObject.Destroy (gameObject);
			}
			yield return new WaitForSeconds (1f);
		}
	}
	// Update is called once per frame
	void Update () {
			
	}
}
