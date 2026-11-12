using UnityEngine;
using UnityEngine.InputSystem;

public class DroneWatering : MonoBehaviour
{
    public InputActionReference inputActionReference;
    public bool IsWatering { get; private set; }
    
    public ParticleSystem waterParticles;
    
    public AudioSource audioSource;
    
    void OnWatering(InputAction.CallbackContext context)
    {
        IsWatering = true;
        waterParticles.Play();
        audioSource.Play();
    }
    
    void StopWatering(InputAction.CallbackContext context)
    {
        IsWatering = false;
        waterParticles.Stop();
        audioSource.Stop();
    }

    void OnEnable()
    {
        if (Time.timeScale > 0)
        {
            inputActionReference.action.Enable();
            inputActionReference.action.performed += OnWatering;
            inputActionReference.action.canceled += StopWatering;
        }
    }

    void OnDisable()
    {
        if (Time.timeScale > 0)
        {
            inputActionReference.action.performed -= OnWatering;
            inputActionReference.action.canceled -= StopWatering;
            inputActionReference.action.Disable();
            IsWatering = false;
        }
    }
}
