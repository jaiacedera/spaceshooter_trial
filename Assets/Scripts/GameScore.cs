using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameScore : MonoBehaviour
{
    Text TextScore;
    int score;

    public int Score
    {
        get
        {
            return this.score;
        }
        set
        {
            this.score = value;
            UpdateScoreTextUI();
        }
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TextScore = GetComponent<Text>();
    }

    // Update is called once per frame
    void UpdateScoreTextUI()
    {
        string scoreStr = string.Format("{0:0000000}", score);
        TextScore.text = scoreStr;
    }
}
