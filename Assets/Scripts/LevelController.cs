﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Prime31;
using System;


public class LevelController : MonoBehaviour {

	public static bool isRetrying = false;
    
    public GameObject roadGO;
	public GameObject playerGO;
	public AnimationCurve rotation;


    public GameObject pauseUI;
    public static LevelController singleton;


	public int laneID = 0;
    public float sideSpeed = 4f;

    public float minSideSpeed = 6f;
    public float maxSideSpeed = 20f;
    public int maxPointCalibrator = 120;
	
    public int sign = 1;

    public Transform gameOverMenuTransform;
    public Transform startMenuTranform;

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

    public static bool isPaused = false;
    public static bool isDisplayingMenu = false;

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
        PauseGame();
        if(isRetrying){
            StartGame();
        }
        else{
            pauseUI.SetActive(false);
        }
        singleton = this;
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
  
    void Update () {

        if (!isPaused) {
            playerGO.transform.Translate(Vector3.forward * playerSpeed * Time.deltaTime, Space.World);
            ChangeLane();

            if (playerGO.transform.position.z > roadCounter * 20f) {

                Instantiate(roadGO, pos + Vector3.forward * 20 * roadCounter, Quaternion.identity);
                roadCounter++;

            }
            playerGO.transform.rotation = Quaternion.Euler(0f, rotation.Evaluate(Mathf.Abs(playerGO.transform.position.x) * sign), 0f);

            playerSpeed += speedIncreaseRate * Time.deltaTime;
            UpdateSideSpeed();
        }
	}

    public void ToggleGameOverMenu(){
        StartCoroutine(BringGameOverMenu());
        isDisplayingMenu = true;
        pauseUI.SetActive(false);
    }

    IEnumerator BringGameOverMenu(){
        while(gameOverMenuTransform.rotation != Quaternion.identity){
            gameOverMenuTransform.localRotation = Quaternion.Lerp(gameOverMenuTransform.localRotation, Quaternion.identity, 0.1f);
            print("rotating");
            yield return new WaitForEndOfFrame();
        }
    }

    

	public void ContinueGame() {
		StopAllCoroutines();
        pauseUI.SetActive(true);
		gameOverMenuTransform.localRotation = Quaternion.Euler(-60f, 0f, 0f);
		isDisplayingMenu = false;
		playerGO.transform.Translate(Vector3.forward * 2);
		isPaused = false;
	}

    public void StartGame(){
        StopAllCoroutines();
        startMenuTranform.localRotation = Quaternion.Euler(-60f, 0f, 0f);
        UnPauseGame();
        pauseUI.SetActive(true);
    }

	void UpdateSideSpeed() {
		var inter = (float)Score / (float)maxPointCalibrator;
		sideSpeed = Mathf.Lerp(minSideSpeed, maxSideSpeed, inter);
		print(inter);
	}

    public void PauseGame(){
        isPaused = true;
    }

    public void UnPauseGame(){
        if(!isDisplayingMenu)
            isPaused = false;
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
        return Input.GetKeyDown(KeyCode.RightArrow) || 
        Input.GetKeyDown(KeyCode.D);
    }

    bool MoveLeft(){
        return Input.GetKeyDown(KeyCode.LeftArrow) || 
        Input.GetKeyDown(KeyCode.A);
    }
}
