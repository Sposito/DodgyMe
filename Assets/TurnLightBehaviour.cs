using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnLightBehaviour : MonoBehaviour {
    public enum Direction { right, left };
    Renderer rend;
    float lastAbsX;
    public Color onColor;
    public Color offColor;
    public Direction dir;
    public float threshhold = 0.01f;

	void Start () {
        rend = GetComponent<Renderer>();
        lastAbsX = transform.position.x;
        rend.material.color = offColor;
	}
	
	// Update is called once per frame
	void Update () {
        rend.material.color = offColor;
        var delta = transform.position.x - lastAbsX;
        if (dir == Direction.right && delta > threshhold){
            
            rend.material.color = onColor;
        }

		if (dir == Direction.left && delta < -threshhold) {

			rend.material.color = onColor;
		}

        lastAbsX = transform.position.x;
	}
}
