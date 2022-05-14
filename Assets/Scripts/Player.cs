using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float xRange = 25.0f;
    private float zRange = 25.0f;
    private float yPos = 1.5f;
    private float xSpawnPos = -24.0f;
    private float stepLength = 2.0f;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        SetSpawnPosition();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            MovePlayer("up"); // Example of Abstraction
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MovePlayer("left");
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            MovePlayer("down");
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            MovePlayer("right");
        }
    }
    void MovePlayer(string direction)
    {
        int stepX = 0;
        int stepZ = 0;
        if (direction == "up")
        {
            stepZ = 1;
        }
        else if (direction == "left")
        {
            stepX = -1;
        }
        else if (direction == "down")
        {
            stepZ = -1;
        }
        else if (direction == "right")
        {
            stepX = 1;
        }
        float newXPos = transform.position.x + stepX * stepLength;
        float newZPos = transform.position.z + stepZ * stepLength;
        if (newXPos < xRange && newXPos > -xRange && newZPos < zRange && newZPos > -zRange) // Check new position is within bounds
        {
            transform.Translate(Vector3.forward * stepZ * stepLength + Vector3.right * stepX * stepLength);
            gameManager.turn++;
            gameManager.EnemyMoves();
        }
    }

    public void SetSpawnPosition()
    {
        float zSpawnPos = Random.Range(-12, 13) * stepLength; // Random z placement
        transform.position = new Vector3(xSpawnPos, yPos, zSpawnPos);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Target"))
        {
            Destroy(other.gameObject);
            gameManager.targets.Remove(other.gameObject);
            gameManager.CheckTargetList();
        }
        else if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject); // Trigger Game Over
            gameManager.GameOver();
        }
    }
}
