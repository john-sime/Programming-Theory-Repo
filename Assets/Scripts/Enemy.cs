using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float xSpawnPos = 24.0f;
    private float yPos = 1.5f;
    private float stepLength = 2.0f;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        SetSpawnPosition();
        player = GameObject.Find("Player");
    }

    void SetSpawnPosition()
    {
        float zSpawnPos = Random.Range(-12, 13) * stepLength; // Random z placement
        transform.position = new Vector3(xSpawnPos, yPos, zSpawnPos);
    }

    public void MakeMove()
    {
        int directionChoice = Random.Range(0, 2);
        float playerX = player.transform.position.x;
        float playerZ = player.transform.position.z;
        if (Mathf.Abs(transform.position.x - playerX) < stepLength / 2) // Enemy on player's x co-ordinate
        {
            directionChoice = 1; // Enemy to move in Z direction
        }
        else if (Mathf.Abs(transform.position.z - playerZ) < stepLength / 2)
        {
            directionChoice = 0; // Enemy to move in X direction
        }
        // Move enemy one step in direction of the player
        if (directionChoice == 0)
        {
            if (playerX > transform.position.x)
            {
                transform.Translate(Vector3.right * stepLength);
            }
            else
            {
                transform.Translate(Vector3.left * stepLength);
            }
        }
        else
        {
            if (playerZ > transform.position.z)
            {
                transform.Translate(Vector3.forward * stepLength);
            }
            else
            {
                transform.Translate(Vector3.back * stepLength);
            }
        }
    }

    public virtual void MoveOrStay(int turn) // Method to be overriden for different enemy types
    {
        MakeMove();
    }
}
