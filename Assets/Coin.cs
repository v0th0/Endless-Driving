using UnityEngine;

public class Coin : MonoBehaviour
{
    public float rotateSpeed = 200f;

    void Update()
    {
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (!GameManager.instance.isGameStarted) return;

        if (other.CompareTag("Player"))
        {
            GameManager.instance.AddScore(1);

            if (DifficultyManager.instance != null)
                DifficultyManager.instance.AddScore(1);

            AudioManager.instance.PlayCoin();

            Destroy(gameObject);
        }
    }
}