using UnityEngine;

public class UpdateScore : MonoBehaviour {

	int score = 0;

	UnityEngine.UI.Text text;

	public bool isMaxScore = false; /*script used to score and max score, this 
    bool should be checked on inspector */

	void Start () {
		text = GetComponent<UnityEngine.UI.Text>();
	}
	
	void Update () {
		if (isMaxScore) {
			if (score != LevelController.maxScore) {
				score = LevelController.maxScore;
				text.text = score + "";
			}
		} 

		else {
			if (score != LevelController.Score) {
				score = LevelController.Score;
				text.text = score + "";
			}
		}	
	}
}
