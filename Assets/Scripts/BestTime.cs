using TMPro;
using UnityEngine;

public class BestTime : MonoBehaviour
{
    public TextMeshProUGUI bestTimeText;
    
    void Start()
    {
        float bestTime = PlayerPrefs.GetFloat("bestTime", 1000.0f);
        if (bestTime == 1000.0f)
        {
            bestTimeText.text = "Meilleur temps : 0s";
        }
        else
        {
            bestTimeText.text = "Meilleur temps : " + bestTime.ToString("F1") + "s";
        }
    }
    
}
