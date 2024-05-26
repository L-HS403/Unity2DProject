using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private int currentScore = 0;
    private int maxScore = 0;

    public TextMeshProUGUI cscoreText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI maxScoreText;

    private void Update()
    {
        cscoreText.text = "Score: " + currentScore.ToString();
    }

    public void AddScore(int score)
    {
        currentScore += score;
    }

    public void ScoreView()
    {
        scoreText.text = "Score: " + currentScore.ToString();
        if (currentScore > maxScore)
        {
            maxScore = currentScore;
        }
        maxScoreText.text = "Max Score: " + maxScore.ToString();
    }

    public void ResetCurrentScore()
    {
        currentScore = 0;
    }
}
