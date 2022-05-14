using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private int xRange = 10;
    private int zRange = 10;
    private float yPos = 1.5f;
    private float stepLength = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        SetSpawnPosition();
    }


    void SetSpawnPosition()
    {
        float xSpawnPos = Random.Range(-xRange, xRange + 1) * stepLength;
        float zSpawnPos = Random.Range(-zRange, zRange + 1) * stepLength;
        transform.position = new Vector3(xSpawnPos, yPos, zSpawnPos);
    }
}
