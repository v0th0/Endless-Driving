using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject menuPanel;
    public TextMeshProUGUI finalScoreText;

    void Start()
    {
        gameOverPanel.SetActive(false);
        menuPanel.SetActive(true);
    }

    public void StartGame()
    {
        menuPanel.SetActive(false);

        GameManager.instance.StartGame();

        // 🔊 Button sound
        AudioManager.instance.PlayButton();
    }

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);

        int score = GameManager.instance.score;
        finalScoreText.text = "Your Score: " + score;

        GameManager.instance.GameOver();
    }

    public void Retry()
    {
        AudioManager.instance.PlayButton();

        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void ExitToMenu()
    {
        AudioManager.instance.PlayButton();

        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}