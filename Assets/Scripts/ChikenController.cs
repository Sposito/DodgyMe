using UnityEngine;

public class ChikenController : MobController {
    AudioSource source;
	protected override void GetMyComponents(){
        source = GetComponent<AudioSource>();
	}
	protected override void ChangeScore(){
		LevelController.Score--;
	}
	protected override void PlayHitSound(){
        source.Play();
	}
}
