using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject fallingBlockPrefab;
    public Vector2 secondsBetweenSpawnsMinMax;
    public Vector2 spawnSizeMinMax;
    public Vector2 rotationMinMax;
    float nextSpawnTime;
    Vector2 screenHalfSize;
    // Start is called before the first frame update
    void Start()
    {
        screenHalfSize = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextSpawnTime)
        {
            float secondsBetweenSpawns = Mathf.Lerp(secondsBetweenSpawnsMinMax.y, secondsBetweenSpawnsMinMax.x, Difficulty.GetDifficultyPercent()); //Check tips notes for more on Lerp (Linear Interpolation)
            nextSpawnTime = Time.time + secondsBetweenSpawns;
            float spawnSize = Random.Range(spawnSizeMinMax.x, spawnSizeMinMax.y);
            Vector2 spawnPoint = new Vector2(Random.Range(-screenHalfSize.x, screenHalfSize.x), screenHalfSize.y + spawnSize);
            GameObject newBlock = (GameObject)Instantiate(fallingBlockPrefab, spawnPoint, Quaternion.Euler(0f, 0f, Random.Range(rotationMinMax.x, rotationMinMax.y)));
            newBlock.transform.localScale = Vector2.one * spawnSize;
        }
    }
}
