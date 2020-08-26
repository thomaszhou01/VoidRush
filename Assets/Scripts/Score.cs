using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour
{
    public Text score;
    public static float timeSurvived;

    void Update()
    {
        timeSurvived = Time.timeSinceLevelLoad;
        score.text = (timeSurvived).ToString("0");
    }
}
