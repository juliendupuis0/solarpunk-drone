using UnityEngine;
using UnityEngine.InputSystem;

public class DroneWatering : MonoBehaviour
{
    public InputActionReference inputActionReference;
    public bool IsWatering { get; private set; }
    
    void OnWatering(InputAction.CallbackContext context)
    {
        IsWatering = true;
    }
    
    void StopWatering(InputAction.CallbackContext context)
    {
        IsWatering = false;
    }

    void OnEnable()
    {
        inputActionReference.action.Enable();
        inputActionReference.action.performed += OnWatering;
        inputActionReference.action.canceled += StopWatering;
    }

    void OnDisable()
    {
        inputActionReference.action.performed -= OnWatering;
        inputActionReference.action.canceled -= StopWatering;
        inputActionReference.action.Disable();
        IsWatering = false;
    }
}
