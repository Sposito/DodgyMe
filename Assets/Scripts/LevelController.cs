using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

	public GameObject roadGO;
	public GameObject playerGO;
	public AnimationCurve rotation;

	public int reachOfVisionUnits = 6;
	int roadCounter = 0;
	public float playerSpeed = 1f;
	Vector3 pos = Vector3.zero;
	void Start () {
		
		for (int i = 0; i < reachOfVisionUnits; i++) {
			
			Instantiate (roadGO, pos, Quaternion.identity);

			pos += Vector3.forward * 20;
		}

		playerGO = (GameObject)Instantiate(playerGO,new Vector3(0f, 0.4f, 0f),Quaternion.identity);
		Camera.main.gameObject.AddComponent<FollowCamera> ();
	}
	
	// Update is called once per frame
	void Update () {
		playerGO.transform.Translate (Vector3.forward * playerSpeed * Time.deltaTime,Space.World);
		ChangeLane ();

		if (playerGO.transform.position.z > roadCounter * 20f) {
			
			Instantiate (roadGO, pos +Vector3.forward * 20 * roadCounter , Quaternion.identity);
			roadCounter++;
			 
		}
		playerGO.transform.rotation = Quaternion.Euler(0f, rotation.Evaluate (Mathf.Abs(playerGO.transform.position.x) * sign), 0f);

	}

	public int laneID = 0;
	public float sideSpeed = 2f;
	public int sign = 1;
	void ChangeLane(){
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			laneID += 1;
			sign = 1;
		} else if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			laneID -= 1;
			sign = -1;
		}
		laneID = Mathf.Clamp (laneID, -1, 1);

		if (playerGO.transform.position.x != (float)laneID * 2) {
			
			playerGO.transform.Translate (((float)laneID * 2 - playerGO.transform.position.x) * Vector3.right * sideSpeed * Time.deltaTime,Space.World);
		}
	}
}
