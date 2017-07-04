using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TreeBehaviour : MonoBehaviour
{

    public Vector3 trunkSize = Vector3.one;
    public Vector3 leavesSize = Vector3.one;

    GameObject trunk;
    GameObject trunkTip;
    GameObject leavesPivot;
    GameObject leaves;

    void Awake()
    {
        trunk = transform.Find("TreeTrunk").gameObject;
        trunkTip = transform.Find("TreeTrunkTip").gameObject;
        leavesPivot = trunkTip.transform.Find("LeavesPivot").gameObject;
        leaves = leavesPivot.transform.Find("Leaves").gameObject;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR

        ApplySizes();

        #endif
	}

   public void ApplySizes(){
        transform.localScale = trunkSize;
        trunkTip.transform.localScale = new Vector3(
            1f / transform.localScale.x * leavesSize.x,
            1f / transform.localScale.y * leavesSize.y,
            1f / transform.localScale.z * leavesSize.z);
    }
}
