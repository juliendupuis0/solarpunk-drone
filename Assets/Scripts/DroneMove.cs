using UnityEngine;
using UnityEngine.InputSystem;

public class DroneMove : MonoBehaviour
{
    public InputActionReference inputActionReference;
    public float speed;

    void Update()
    {
        Vector2 input = inputActionReference.action.ReadValue<Vector2>();
        Vector3 inputVector = new Vector3(input.x, 0, input.y); // pour se déplacer sur le plan horizontal vu de dessus
        transform.Translate(inputVector * speed * Time.deltaTime);
    }
    
    void OnEnable()
    {
        inputActionReference.action.Enable();
    }
    
    void OnDisable()
    {
        inputActionReference.action.Disable();
    }
}
