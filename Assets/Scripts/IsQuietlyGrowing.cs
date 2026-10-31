using UnityEngine;

public class IsQuietlyGrowing : MonoBehaviour
{
    public float minDuration = 2.5f; // doit être strictement positif
    public float maxDuration = 7.0f;
    public float randomDuration;
    
    public Vector3 initialScale;
    public Vector3 finalScale;

    private float timeCurrent;
    
    void Start()
    {
        randomDuration = Random.Range(minDuration, maxDuration);
        transform.localScale = initialScale;
    }

    void Update()
    {
        timeCurrent += Time.deltaTime;
        // interpolation linéaire de 0 à 1. condition de fin : timeCurrent >= randomDuration
        transform.localScale = Vector3.Lerp(initialScale, finalScale, timeCurrent / randomDuration);
    }
}
