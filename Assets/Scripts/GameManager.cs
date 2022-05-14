using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int turn = 0;
    public int level = 1;
    [SerializeField] GameObject player;
    [SerializeField] GameObject targetPrefab;
    [SerializeField] List<GameObject> enemyPrefabList;
    public List<GameObject> targets = new List<GameObject>();
    public List<GameObject> enemies = new List<GameObject>();
    private int highScore;
    private MainUIHandler mainUIHandler;
    [SerializeField] GameObject gameOverScreen;

    // Start is called before the first frame update
    void Start()
    {
        highScore = ScoreManager.Instance.highScore;
        mainUIHandler = GameObject.Find("Canvas").GetComponent<MainUIHandler>();
        NewLevel();
    }

    void NewLevel()
    {
        turn = 0;
        player.GetComponent<Player>().SetSpawnPosition();
        int numberOfTargets = (level - 1) % 3 + 1; // 1 for levels 1,4,7, etc, 2 for levels 2,5,8, etc, 3 for levels 3,6,9, etc
        int numberOfEnemies = (level + 2) / 3; // 1 for levels 1,2,3, then 2 for levels 4,5,6 and so on
        for (int i = 1; i <= numberOfTargets; i++)
        {
            targets.Add(Instantiate(targetPrefab));
        }
        for (int i = 1; i <= numberOfEnemies; i++)
        {
            enemies.Add(Instantiate(enemyPrefabList[Random.Range(0, 2)]));
        }
    }

    public void CheckTargetList()
    {
        if (targets.Count == 0)
        {
            level++;
            mainUIHandler.UpdateScore(level);
            foreach (GameObject enemy in enemies)
            {
                Destroy(enemy.gameObject);
            }
            enemies.Clear();
            NewLevel();
        }
    }

    public void EnemyMoves()
    {
        foreach (GameObject enemy in enemies)
        {
            if (enemy.GetComponent<RedEnemy>() != null) // Enemy is Red
            {
                enemy.GetComponent<RedEnemy>().MoveOrStay(turn);
            }
            else if (enemy.GetComponent<PurpleEnemy>() != null) // Enemy is purple
            {
                enemy.GetComponent<PurpleEnemy>().MoveOrStay(turn);
            }
        }
    }

    public void GameOver()
    {
        int score = level - 1;
        if (score > highScore)
        {
            ScoreManager.Instance.score = score;
            ScoreManager.Instance.SaveScore();
            mainUIHandler.UpdateHighScore(score);
            gameOverScreen.SetActive(true);
        }
    }
}
