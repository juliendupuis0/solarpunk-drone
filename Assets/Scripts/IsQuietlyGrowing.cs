using UnityEngine;

public class IsQuietlyGrowing : MonoBehaviour
{
    public float minDuration = 2.5f; // doit être strictement positif
    public float maxDuration = 7.0f;
    public float randomDuration;
    
    public Vector3 initialScale;
    public Vector3 finalScale;

    private float _timeCurrent;
    
    public float rottenDuration = 10.0f;

    private enum ColorState
    {
        Initial,
        Rotting,
        Rotten
    };
    
    private ColorState _colorState = ColorState.Initial;
    
    void Start()
    {
        randomDuration = Random.Range(minDuration, maxDuration);
        transform.localScale = initialScale;
    }

    void Update()
    {
        _timeCurrent += Time.deltaTime;
        // interpolation linéaire de 0 à 1. condition de fin : timeCurrent >= randomDuration
        transform.localScale = Vector3.Lerp(initialScale, finalScale, _timeCurrent / randomDuration);
        if (_timeCurrent >= randomDuration)
        {
            GetComponent<Renderer>().material.color = Color.forestGreen;
            _colorState = ColorState.Rotting;
        }
        if (_timeCurrent >= rottenDuration)
        {
            GetComponent<Renderer>().material.color = Color.saddleBrown;
            _colorState = ColorState.Rotten;
        }
    }
}
