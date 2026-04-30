using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("Audio Sources")]
    public AudioSource musicSource;
    public AudioSource sfxSource;

    [Header("Music")]
    public AudioClip menuMusic;
    public AudioClip gameplayMusic;
    private AudioClip currentMusic;

    [Header("SFX")]
    public AudioClip engineLoop;
    public AudioClip laneSwitch;
    public AudioClip crash;
    public AudioClip buttonClick;
    public AudioClip coinCollect;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayMusic(AudioClip clip)
    {
        if (clip == null) return;
        if (currentMusic == clip && musicSource.isPlaying) return;

        currentMusic = clip;

        musicSource.Stop();
        musicSource.clip = clip;
        musicSource.loop = true;
        musicSource.volume = 0.4f;
        musicSource.Play();
    }

    public void PlayMenuMusic() => PlayMusic(menuMusic);
    public void PlayGameplayMusic() => PlayMusic(gameplayMusic);

    public void PlaySFX(AudioClip clip, float volume = 1f)
    {
        if (clip == null) return;
        sfxSource.PlayOneShot(clip, volume);
    }

    public void PlayCoin() => PlaySFX(coinCollect, 0.7f);
    public void PlayLaneSwitch() => PlaySFX(laneSwitch, 0.4f);
    public void PlayCrash() => PlaySFX(crash, 1f);
    public void PlayButton() => PlaySFX(buttonClick, 0.8f);
}