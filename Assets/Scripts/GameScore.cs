using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScore : MonoBehaviour
{
    public Text score;
    private float scoreNum;

    // Start is called before the first frame update
    void OnEnable()
    {
        scoreNum = Score.timeSurvived;
        score.text = ("Your score is: " + scoreNum.ToString("0"));
    }


}
