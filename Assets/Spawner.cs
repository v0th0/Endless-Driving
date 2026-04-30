using UnityEngine;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{
    public GameObject[] obstacles;
    public GameObject[] pairObstacles;
    public GameObject coinPrefab;
    public Transform player;

    public float spawnDistance = 40f;
    public float rowSpacing = 20f;

    public float[] lanes = { -9f, 0f, 9f };

    public bool spawnEnabled = false;

    private float nextSpawnX;

    void Start()
    {
        nextSpawnX = player.position.x + spawnDistance;
    }

    void Update()
    {
        if (!spawnEnabled) return;

        if (player.position.x + spawnDistance > nextSpawnX)
        {
            SpawnRow(nextSpawnX);
            nextSpawnX += rowSpacing;
        }
    }

    void SpawnRow(float xPos)
    {
        int obstacleCount = Random.Range(1, 3);
        bool[] usedLanes = new bool[lanes.Length];

        // ✅ PAIR OBSTACLE
        if (obstacleCount == 2 && pairObstacles.Length > 0)
        {
            int startLane = Random.Range(0, lanes.Length - 1);

            GameObject pair = pairObstacles[Random.Range(0, pairObstacles.Length)];

            float zCenter = (lanes[startLane] + lanes[startLane + 1]) / 2f;

            // ✅ ROTATION FIX
            Quaternion rot = Quaternion.Euler(0, -90f, 0f);

            Instantiate(pair, new Vector3(xPos, 0f, zCenter), rot);

            usedLanes[startLane] = true;
            usedLanes[startLane + 1] = true;
        }
        else
        {
            List<int> laneIndices = new List<int> { 0, 1, 2 };
            Shuffle(laneIndices);

            for (int i = 0; i < obstacleCount; i++)
            {
                int lane = laneIndices[i];
                usedLanes[lane] = true;

                Instantiate(
                    obstacles[Random.Range(0, obstacles.Length)],
                    new Vector3(xPos, 0f, lanes[lane]),
                    Quaternion.identity
                );
            }
        }

        // ✅ COINS
        for (int i = 0; i < lanes.Length; i++)
        {
            if (!usedLanes[i])
            {
                for (int j = 0; j < 4; j++)
                {
                    Instantiate(
                        coinPrefab,
                        new Vector3(xPos + j * 2.5f, 1.2f, lanes[i]),
                        Quaternion.identity
                    );
                }
            }
        }
    }

    public void ResetSpawner()
    {
        nextSpawnX = player.position.x + spawnDistance;
    }

    void Shuffle(List<int> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int rand = Random.Range(i, list.Count);
            int temp = list[i];
            list[i] = list[rand];
            list[rand] = temp;
        }
    }
}