using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 20.0f;
    public float maxTurnAngle = 30f;
    public float turnSmooth = 5f;

    public ParticleSystem leftSmoke;
    public ParticleSystem rightSmoke;

    private float horizontalInput;
    private float currentYRotation;

    private AudioSource engineSource;

    void Start()
    {
        engineSource = gameObject.AddComponent<AudioSource>();
        engineSource.clip = AudioManager.instance.engineLoop;
        engineSource.loop = true;
        engineSource.volume = 0.5f;
    }

    void Update()
    {
        // ❌ Stop in menu
        if (!GameManager.instance.isGameStarted)
        {
            StopEffects();
            return;
        }

        horizontalInput = Input.GetAxis("Horizontal");

        // ✅ FORWARD (Z axis)
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // ✅ TURN (Y rotation)
        float targetRotation = horizontalInput * maxTurnAngle;
        currentYRotation = Mathf.Lerp(currentYRotation, targetRotation, turnSmooth * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0, 90 + currentYRotation, 0);

        HandleSmoke();

        if (!engineSource.isPlaying)
            engineSource.Play();
    }

    void HandleSmoke()
    {
        if (horizontalInput < -0.1f)
        {
            if (!leftSmoke.isPlaying) leftSmoke.Play();
            if (rightSmoke.isPlaying) rightSmoke.Stop();
        }
        else if (horizontalInput > 0.1f)
        {
            if (!rightSmoke.isPlaying) rightSmoke.Play();
            if (leftSmoke.isPlaying) leftSmoke.Stop();
        }
        else
        {
            StopEffects();
        }
    }

    void StopEffects()
    {
        if (leftSmoke.isPlaying) leftSmoke.Stop();
        if (rightSmoke.isPlaying) rightSmoke.Stop();

        if (engineSource.isPlaying)
            engineSource.Stop();
    }
}