using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public static DifficultyManager instance;

    public float difficulty = 1f;
    private int score = 0;

    void Awake()
    {
        // Singleton setup (safe)
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Call this when player earns score
    public void AddScore(int value)
    {
        score += value;

        // Increase difficulty gradually
        difficulty = 1f + (score * 0.03f);

        // Clamp max difficulty
        difficulty = Mathf.Clamp(difficulty, 1f, 5f);
    }

    // Get number of obstacles based on difficulty
    public int GetObstacleCount()
    {
        if (difficulty < 2f)
            return 1; // Easy

        else if (difficulty < 3.5f)
            return 2; // Medium

        else
            return Random.Range(2, 4); // Hard (2 or 3)
    }

    // Optional: reset (for restart)
    public void ResetDifficulty()
    {
        difficulty = 1f;
        score = 0;
    }
}