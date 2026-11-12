using TMPro;
using UnityEngine;

public class BestTime : MonoBehaviour
{
    public TextMeshProUGUI bestTimeText;
    public float bestTime;

    void Start()
    {
        bestTime = PlayerPrefs.GetFloat("bestTime", 1000.0f);
        bestTimeText.text = "Best Time : " + "0";
    }

    void Update()
    {
        bestTimeText.text = "Best Time : " + bestTime.ToString("F1") + "secondes";
    }
}
