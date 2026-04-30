using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score = 0;
    public TextMeshProUGUI scoreText;

    public bool isGameStarted = false;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Time.timeScale = 0f;

        if (scoreText != null)
            scoreText.gameObject.SetActive(false);
    }

    public void StartGame()
    {
        score = 0;
        isGameStarted = true;

        Time.timeScale = 1f;

        if (scoreText != null)
        {
            scoreText.gameObject.SetActive(true);
            scoreText.text = "Score: 0";
        }
    }

    public void AddScore(int amount)
    {
        if (!isGameStarted) return;

        score += amount;

        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        isGameStarted = false;
        Time.timeScale = 0f;

        int best = PlayerPrefs.GetInt("BestScore", 0);
        if (score > best)
        {
            PlayerPrefs.SetInt("BestScore", score);
        }
    }

    public void ResetGame()
    {
        score = 0;
        isGameStarted = false;

        if (scoreText != null)
        {
            scoreText.text = "Score: 0";
            scoreText.gameObject.SetActive(false);
        }

        Time.timeScale = 0f;
    }
}