using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

/// <summary> Behaviour of barricade game objects that resets the game at collision. </summary>
public class BarricadeBehaviour : MonoBehaviour {

    bool firstHit = true;

	void Start () {
		int p = Random.Range (-1, 2);
		transform.position = new Vector3 (p * 2f, transform.position.y, transform.position.z);
	}

	void OnCollisionEnter(Collision col){
        if (firstHit)
            StartCoroutine(WaitClip());
	}

    IEnumerator WaitClip(){
        firstHit = false;
        AudioSource source = GetComponent<AudioSource>();
        source.Play();
        yield return new WaitForSeconds(source.clip.length);
		LevelController.SubmitScore();
		//Reset Score
		LevelController.Score = 0;
		//Reload Scene
		SceneManager.LoadScene(0);
    }

}
