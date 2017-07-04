using UnityEngine;

public class LookAtPlayer : MonoBehaviour {
	Transform playerT;
	// Use this for initialization
	void Start () {
		playerT = GameObject.FindGameObjectWithTag ("Player").transform;	
	}

	void Update () {
		transform.LookAt (playerT);
		if (transform.position.y >1f)
			Destroy(gameObject.GetComponent<LookAtPlayer>());
	}
}