using UnityEngine;
using UnityEngine.InputSystem;

public class DroneMove : MonoBehaviour
{
    public InputActionReference inputActionReference;
    public float speed;

    void Update()
    {
        Vector2 input = inputActionReference.action.ReadValue<Vector2>();
        // pour se déplacer sur le plan horizontal vu de dessus
        Vector3 inputVector = new Vector3(input.x, 0, input.y);
        transform.Translate(inputVector * speed * Time.deltaTime);
        // autorise le déplacement du drone uniquement sur le champ
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -10, 10), transform.position.y, Mathf.Clamp(transform.position.z, -10, 10));
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
