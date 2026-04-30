using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public UIManager uiManager;

    private void OnCollisionEnter(Collision collision)
    {
        if (!GameManager.instance.isGameStarted) return;

        if (collision.gameObject.CompareTag("Obstacles"))
        {
            AudioManager.instance.PlayCrash();

            GameManager.instance.GameOver();
            uiManager.ShowGameOver();
        }
    }
}