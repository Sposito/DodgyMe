using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Prime31;

public class InputHandler : MonoBehaviour {

    TKLSwipeDetector detector;
    public LevelController levelController;
    public static InputHandler singleton;

	void Awake () {
        DontDestroyOnLoad(gameObject);
        detector = GetComponent<TKLSwipeDetector>();
        if (singleton == null){
            singleton = this;
        }

        detector.onSwipeDeteced += HandleInput;
	}

    void HandleInput(SwipeDirection dir){
        if (levelController != null){
            levelController.HandleSwipe(dir);
        }
    }
	

}
