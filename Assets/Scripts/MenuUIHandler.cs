using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI highScoreText;
    [SerializeField] TMP_InputField playerNameInput;

    // Start is called before the first frame update
    void Start()
    {
        string highScoreName = ScoreManager.Instance.highScoreName;
        int highScore = ScoreManager.Instance.highScore;
        if (highScoreName != "" && highScore > 0)
        {
            highScoreText.text = "High Score : " + highScoreName + " : " + highScore;
        }
    }

    public void StartNew()
    {
        if (playerNameInput.text != "")
        {
            ScoreManager.Instance.playerName = playerNameInput.text;
            SceneManager.LoadScene(1);
        }
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
