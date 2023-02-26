using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    int score;
    TMP_Text scoreText;

    void Start()
    {
        scoreText = GetComponent<TMP_Text>();
        scoreText.text = "Game Start!";
    }

    public void KeepScore(int amountOfScore)
    {
        score += amountOfScore;
        scoreText.text = score.ToString();
    }
}
