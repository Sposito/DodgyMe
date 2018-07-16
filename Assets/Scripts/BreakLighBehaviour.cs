using UnityEngine;

/// <summary> Behaviour that changes material color of breaklighs. </summary>
public class BreakLighBehaviour : MonoBehaviour {

	Renderer rend;
	float lastAbsZ;
	public Color onColor;
	public Color offColor;

	public float threshhold = 0.01f;

	void Start() {
		rend = GetComponent<Renderer>();
        lastAbsZ = transform.position.z;
		rend.material.color = offColor;
	}

	// Update is called once per frame
	void Update() {
        
		rend.material.color = offColor;
		var delta = transform.position.z - lastAbsZ;
		if (delta < threshhold) {
			rend.material.color = onColor;
		}

		lastAbsZ = transform.position.z;
	}
}
