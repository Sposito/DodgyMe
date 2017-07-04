using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Prime31;
using System;

public class LevelController : MonoBehaviour {

	public GameObject roadGO;
	public GameObject playerGO;
	public AnimationCurve rotation;


	public int laneID = 0;
	public float sideSpeed = 2f;
	public int sign = 1;

    public float speedIncreaseRate = 0.06f;

	public int reachOfVisionUnits = 6;
	int roadCounter = 0;
	public float playerSpeed = 1f;
	Vector3 pos = Vector3.zero;

    AudioSource swipeSound;

	public static int Score {
		get{ return _score; }
		set {
			_score = value;
			if (_score < 0)
				_score = 0;
		}
	}
	public static int maxScore = 0;

	public static void SubmitScore(){
		if (_score <= maxScore)
			return;
		maxScore = _score;
		PlayerPrefs.SetInt ("MaxScore", maxScore);
		PlayerPrefs.Save ();
	}

			
	static int _score;

	void Awake () {
		
		for (int i = 0; i < reachOfVisionUnits; i++) {
			
			Instantiate (roadGO, pos, Quaternion.identity);

			pos += Vector3.forward * 20;
		}

		playerGO = Instantiate(playerGO,new Vector3(0f, 0.4f, 0f),Quaternion.identity);
		Camera.main.gameObject.AddComponent<FollowCamera> ();
		maxScore = PlayerPrefs.GetInt ("MaxScore", 0);
        swipeSound = playerGO.GetComponent<AudioSource>();


    
	}

    void Start(){
        InputHandler.singleton.levelController = this;
    }
  
    public void HandleSwipe(SwipeDirection dir){
        
		if (dir == SwipeDirection.Right){
			laneID += 1;
			sign = 1;
            swipeSound.Play();
		}
		else if (dir == SwipeDirection.Left){
			laneID -= 1;
			sign = -1;
            swipeSound.Play();
		}
		laneID = Mathf.Clamp(laneID, -1, 1);

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

		playerSpeed += speedIncreaseRate * Time.deltaTime;

	}

	void ChangeLane(){
        if (MoveRight()) {
			laneID += 1;
			sign = 1;
            swipeSound.Play();
        } 

        else if (MoveLeft()) {
			laneID -= 1;
			sign = -1;
            swipeSound.Play();
		}
		laneID = Mathf.Clamp (laneID, -1, 1);

		if (playerGO.transform.position.x != (float)laneID * 2) {
			
			playerGO.transform.Translate (((float)laneID * 2 - playerGO.transform.position.x) * Vector3.right * sideSpeed * Time.deltaTime,Space.World);
		}
	}

   

    bool MoveRight(){
        
        return Input.GetKeyDown(KeyCode.RightArrow);
    }

    bool MoveLeft(){
        return Input.GetKeyDown(KeyCode.LeftArrow);
    }


}
