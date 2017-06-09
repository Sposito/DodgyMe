using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary> Behaviour of barricade game objects that resets the game at collision. </summary>
public class BarricadeBehaviour : MonoBehaviour {

	void Start () {
		int p = Random.Range (-1, 2);
		transform.position = new Vector3 (p * 2f, transform.position.y, transform.position.z);
	}

	void OnCollisionEnter(Collision col){
		
		LevelController.SubmitScore ();
		//Reset Score
        LevelController.Score = 0;
		//Reload Scene
        SceneManager.LoadScene (0);

	}
}
