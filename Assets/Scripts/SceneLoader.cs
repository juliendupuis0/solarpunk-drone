using UnityEngine;
using UnityEngine.SceneManagement;

// chargement des scènes

public class SceneLoader : MonoBehaviour
{
      public void LoadScene(string nameScene)
      { 
            SceneManager.LoadSceneAsync(nameScene);
      }
        
      public void ExitGame()
      {
            Application.Quit();
      }
}
