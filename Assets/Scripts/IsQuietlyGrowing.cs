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
    
    public float durationBeforeDestroy = 3.0f;

    public float bonusTime = 0.0f;
    
    private bool _isReceivingWater = false;
    
    private Animator _animator;

    public enum ColorState // pour savoir à quel état est la graine ailleurs dans un autre script
    {
        Initial,
        Ripe,
        Rotten
    };
    
    public ColorState colorState = ColorState.Initial;
    
    void Start()
    {
        randomDuration = Random.Range(minDuration, maxDuration);
        transform.localScale = initialScale;
        _animator = GetComponentInParent<Animator>();
    }

    void Update()
    {
        _timeCurrent += Time.deltaTime;
        // si l'eau est bien dans la zone alors le bonus s'applique
        if (_isReceivingWater)
        {
            _timeCurrent += bonusTime * Time.deltaTime;
        }
        // interpolation linéaire de 0 à 1. condition de fin : timeCurrent >= randomDuration
        transform.localScale = Vector3.Lerp(initialScale, finalScale, _timeCurrent / randomDuration);
        if (_timeCurrent >= randomDuration && colorState == ColorState.Initial)
        {
            GetComponent<Renderer>().material.color = Color.forestGreen;
            colorState = ColorState.Ripe;
            _animator.SetTrigger("Ripe");
        }
        if (_timeCurrent >= rottenDuration && colorState == ColorState.Ripe)
        {
            GetComponent<Renderer>().material.color = Color.saddleBrown;
            colorState = ColorState.Rotten;
            _animator.SetTrigger("Rotten");
            Destroy(transform.root.gameObject, durationBeforeDestroy);
        }
    }
    
    public void SetIsReceivingWater(bool isReceivingWater)
    {
        _isReceivingWater = isReceivingWater;
    }
}
