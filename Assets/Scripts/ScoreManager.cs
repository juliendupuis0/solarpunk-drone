using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int _nbSeedsHarvested = 0;

    public TextMeshProUGUI textScore;
    
    public AudioSource audioSource;
    public AudioClip harvestSound;

    void Start()
    {
        textScore.text = "Score : " + _nbSeedsHarvested;
    }
    
    public void AddPoint()
    {
        _nbSeedsHarvested++;
        textScore.text = "Score : " + _nbSeedsHarvested;
        audioSource.PlayOneShot(harvestSound);
    }
}
