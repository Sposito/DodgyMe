using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieColorSetter : MonoBehaviour {

	public GameObject[] bodyParts;
	public Color[] colors;
	void Start () {
		int index = Random.Range (0, colors.Length);
		for (int i = 0; i < bodyParts.Length; i++) {
			bodyParts [i].GetComponent<Renderer>().material.color = colors [index];
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
