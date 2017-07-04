using UnityEngine;

public class RandomizePitch : MonoBehaviour {
    public float min = 1f;
    public float max = 1f;
	
    void Start () {
        GetComponent<AudioSource>().pitch *= Random.Range(min,max);
	}	
}