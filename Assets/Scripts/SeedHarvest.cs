using UnityEngine;

// script associé à l'objet Seed

public class SeedHarvest : MonoBehaviour
{
    private IsQuietlyGrowing _seedGrowing;
    
    private bool _droneIsHere;
    
    void Start()
    {
        _seedGrowing = GetComponentInChildren<IsQuietlyGrowing>();
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Drone"))
        {   
            _droneIsHere = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Drone"))
        {
            // le drone est parti 
            _droneIsHere = false;
        }
    }

    private void Update()
    {
        if (_droneIsHere && _seedGrowing.colorState == IsQuietlyGrowing.ColorState.Ripe)
        {
            Destroy(gameObject);
        }
    }
}
