using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour
{
    public Text score;

    void Update()
    {
        score.text = (Time.timeSinceLevelLoad).ToString("0");
    }
}
