using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeRandomizer : MonoBehaviour {

    TreeBehaviour treeBehaviour;
    public Vector2 leavesVar = Vector2.zero;
    public Vector2 trunkVar = Vector2.zero;
	void Start () {
        treeBehaviour = GetComponent<TreeBehaviour>();
        treeBehaviour.trunkSize += Vector3.up * Random.Range(trunkVar.x, trunkVar.y);
        treeBehaviour.leavesSize += Vector3.up * Random.Range(leavesVar.x, leavesVar.y);
        treeBehaviour.ApplySizes();

        Destroy(treeBehaviour, 0f);
        Destroy(this, 0f);
	}
	
	
}
