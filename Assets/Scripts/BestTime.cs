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
            bestTimeText.text = "Best Time : 0";
        }
        else
        {
            bestTimeText.text = "Best Time : " + bestTime.ToString("F1");
        }
    }
    
}
