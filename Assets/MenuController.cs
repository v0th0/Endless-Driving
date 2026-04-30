using UnityEngine;
using TMPro;

public class MenuController : MonoBehaviour
{
    public GameObject menuPanel;
    public Spawner spawner;
    public TextMeshProUGUI bestScoreText;

    void Start()
    {
        int best = PlayerPrefs.GetInt("BestScore", 0);
        bestScoreText.text = "Best Score: " + best;

        // ❌ Disable gameplay systems
        if (spawner != null)
            spawner.spawnEnabled = false;

        GameManager.instance.ResetGame();

        // 🎵 Menu Music
        if (AudioManager.instance != null)
            AudioManager.instance.PlayMenuMusic();
    }

    public void PlayGame()
    {
        AudioManager.instance.PlayButton();

        // Hide menu
        menuPanel.SetActive(false);

        // ✅ Start game
        GameManager.instance.StartGame();

        // ✅ Enable spawning
        if (spawner != null)
            spawner.spawnEnabled = true;

        // 🎮 Gameplay Music
        if (AudioManager.instance != null)
            AudioManager.instance.PlayGameplayMusic();
    }
}