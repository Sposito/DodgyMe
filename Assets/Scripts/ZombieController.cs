﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MobController {
	protected override void ChangeScore(){
		LevelController.Score++;
	}

}
