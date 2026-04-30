using UnityEngine;

public class EnvironmentFollow : MonoBehaviour
{
    public Transform player;
    public float followSpeed = 1f; // 1 = exact follow, <1 = parallax

    void LateUpdate()
    {
        Vector3 targetPos = new Vector3(
            player.position.x,
            transform.position.y,
            player.position.z
        );

        transform.position = Vector3.Lerp(transform.position, targetPos, followSpeed);
    }
}