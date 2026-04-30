using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    public GameObject roadPrefab;
    public Transform player;

    public int initialTiles = 5;
    public float tileLength = 20f; // ✅ MUST match road size (X scale)

    private float spawnX = 0f;
    private List<GameObject> activeTiles = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < initialTiles; i++)
        {
            SpawnTile();
        }
    }

    void Update()
    {
        // ✅ Spawn ahead smoothly
        if (player.position.x + 100f > spawnX)
        {
            SpawnTile();
            DeleteOldTile();
        }
    }

    void SpawnTile()
    {
        GameObject tile = Instantiate(roadPrefab, new Vector3(spawnX, 0, 0), Quaternion.identity);
        activeTiles.Add(tile);
        spawnX += tileLength;
    }

    void DeleteOldTile()
    {
        if (activeTiles.Count > initialTiles)
        {
            Destroy(activeTiles[0]);
            activeTiles.RemoveAt(0);
        }
    }
}