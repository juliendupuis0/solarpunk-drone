using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public InputActionReference pauseMenuInput;
    
    public GameObject pauseMenu;

    public void OnEnable()
    {
        pauseMenuInput.action.performed += OnPauseMenuInput;
    }

    private void OnDisable()
    {
        pauseMenuInput.action.performed -= OnPauseMenuInput;
    }

    private void OnPauseMenuInput(InputAction.CallbackContext context)
    {
        pauseMenu.SetActive(!pauseMenu.activeSelf);
    }
    
    public void Resume()
    {
        pauseMenu.SetActive(false);
    }

}
