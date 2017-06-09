using UnityEngine;

/// <summary>
/// Randomizes buildings props height
/// </summary>
public class RandomizeBuiding : MonoBehaviour{
    float maxVariance = 7f;
    void Start()
    {
        float height = Random.Range(1f, maxVariance);
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * height, transform.localScale.z);
    }

}
