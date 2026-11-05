using UnityEngine;

public class DroneDetector : MonoBehaviour
{
    private DroneWatering _droneAboveSeed; // on va récupérer le drone qui est au dessus de la graine
    private IsQuietlyGrowing _scriptOfQuietlyGrowing;
    
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Drone"))
        {
            _droneAboveSeed = other.gameObject.GetComponent<DroneWatering>();
        }
    }
    
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Drone"))
        {
            _droneAboveSeed = null;
        }
    }
    
    void Start()
    {
        _scriptOfQuietlyGrowing = GetComponentInChildren<IsQuietlyGrowing>();
    }

    private void Update()
    {
        if (_scriptOfQuietlyGrowing)
        {
            if (_droneAboveSeed && _droneAboveSeed.IsWatering)
            {
                _scriptOfQuietlyGrowing.SetIsReceivingWater(true);
            }
            else
            {
                _scriptOfQuietlyGrowing.SetIsReceivingWater(false);
            }
        }
    }
}
