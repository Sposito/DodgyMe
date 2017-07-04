using UnityEngine;

/// <summary>Base Class that handle creatures that appears on the road.</summary>
public class MobController : MonoBehaviour {
	Rigidbody rb;
    bool scored = false; // variable that ensures that score is only counted once.

    //Components of Force applied on Collision
    float xForceRange = 200f; //x forces is randomized during collsion
    float yForce = 500f;
    float zForce = 900f;

    float pitchTorque = 500000; // x axis
    float rollTorque = 5000; // z axis

    void Awake () {
		rb = GetComponent<Rigidbody> ();
	}

	void Start(){
		int p = Random.Range (-1, 2); // -1, 0 or 1
        //Randomly places mob in one of the three lanes
		transform.position = new Vector3 (p * 2f, transform.position.y, transform.position.z);
        GetMyComponents();
	}

	void OnTriggerEnter(Collider col){
		if (col.CompareTag ("Player")) { //guarantees the collsion occurred with the player 
			rb.AddForce (Random.Range(-xForceRange, xForceRange) * Vector3.right + // X
                         Vector3.up * yForce + //Y
                         Vector3.forward * zForce); //Z
            
            rb.AddTorque (Vector3.right * pitchTorque + Vector3.forward * rollTorque);
            PlayHitSound();
            if (!scored) {
				ChangeScore ();
				scored = true; //guarantees thar core is only counted once.
			}
		}
	}

	protected virtual void ChangeScore(){
		//Change Score is defined in child classes
	}

	protected virtual void GetMyComponents(){
		//GetComponents is defined in child classes
	}

	protected virtual void PlayHitSound(){
		//PlayHitSound is defined in child classes
	}
}