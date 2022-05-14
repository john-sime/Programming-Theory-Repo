using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainUIHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI playerNameText;
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] TextMeshProUGUI highScoreText;
    private string playerName;

    // Start is called before the first frame update
    void Start()
    {
        playerName = ScoreManager.Instance.playerName;
        string highScoreName = ScoreManager.Instance.highScoreName;
        int highScore = ScoreManager.Instance.highScore;
        playerNameText.text = playerName;
        if (highScoreName != "" && highScore > 0)
        {
            highScoreText.text = "High Score\n" + highScoreName + " : " + highScore;
        }
    }

    public void UpdateScore(int score)
    {
        levelText.text = "Level: " + score;
    }

    public void UpdateHighScore(int score)
    {
        highScoreText.text = "High Score\n" + playerName + " : " + score;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }
}
