using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    private Vector3 offset;

    void Start()
    {
        // Automatically calculate offset based on initial position
        offset = transform.position - player.position;
    }

    void LateUpdate()
    {
        if (player == null) return;

        transform.position = player.position + offset;
    }
}
