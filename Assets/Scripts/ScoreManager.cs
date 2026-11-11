using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    private int _nbSeedsHarvested = 0;

    public TextMeshProUGUI textScore;
    
    public AudioSource audioSource;
    public AudioClip harvestSound;

    public int objectiveScore = 30;

    void Start()
    {
        textScore.text = "Score : " + _nbSeedsHarvested;
    }
    
    public void AddPoint()
    {
        _nbSeedsHarvested++;
        textScore.text = "Score : " + _nbSeedsHarvested;
        audioSource.PlayOneShot(harvestSound);
        CheckObjective();
    }

    private void CheckObjective()
    {
        if (_nbSeedsHarvested >= objectiveScore)
        {
            SceneManager.LoadScene("End");
        }
    }
}
