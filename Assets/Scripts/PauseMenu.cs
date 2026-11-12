using UnityEngine;
using UnityEngine.InputSystem;

// gère le menu pause : met en pause le jeu, rend impossible toute action du joueur

public class PauseMenu : MonoBehaviour
{
    public InputActionReference pauseMenuInput;
    
    public GameObject pauseMenu;
    
    private bool _isPaused;


    public void OnEnable()
    {
        pauseMenuInput.action.performed += OnPauseMenuInput;
    }

    private void OnDisable()
    {
        pauseMenuInput.action.performed -= OnPauseMenuInput;
        Time.timeScale = 1;
    }

    private void OnPauseMenuInput(InputAction.CallbackContext context)
    {
        _isPaused = !_isPaused;
        pauseMenu.SetActive(_isPaused);
        Time.timeScale = _isPaused ? 0 : 1;
    }
    
    // pour reprendre le jeu
    public void Resume()
    {
        _isPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

}
