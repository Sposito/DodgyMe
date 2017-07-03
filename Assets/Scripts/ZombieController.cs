using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MobController {
	protected override void ChangeScore(){
		LevelController.Score++;
	}

	AudioSource source;
	protected override void GetMyComponents()
	{
		source = GetComponent<AudioSource>();
	}
	
	protected override void PlayHitSound()
	{
		source.Play();
	}

}
