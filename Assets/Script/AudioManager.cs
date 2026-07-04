using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [Header("Audio Sources")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;

    [Header("Music")]
    [SerializeField] private AudioClip backgroundMusic;

    [Header("SFX")]
    [SerializeField] private AudioClip coinSound;
    [SerializeField] private AudioClip playerAttackSound;
    [SerializeField] private AudioClip enemyHitSound;
    [SerializeField] private AudioClip enemyDeathSound;
    [SerializeField] private AudioClip playerDeathSound;
    [SerializeField] private AudioClip winSound;
    [SerializeField] private AudioClip buttonClickSound;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        PlayBackgroundMusic();
    }

    private void PlayBackgroundMusic()
    {
        if (musicSource == null || backgroundMusic == null) return;

        musicSource.clip = backgroundMusic;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void PlayCoinSound()
    {
        PlaySfx(coinSound);
    }

    public void PlayPlayerAttackSound()
    {
        PlaySfx(playerAttackSound);
    }

    public void PlayEnemyHitSound()
    {
        PlaySfx(enemyHitSound);
    }

    public void PlayEnemyDeathSound()
    {
        PlaySfx(enemyDeathSound);
    }

    public void PlayPlayerDeathSound()
    {
        PlaySfx(playerDeathSound);
    }

    public void PlayWinSound()
    {
        PlaySfx(winSound);
    }

    public void PlayButtonClickSound()
    {
        PlaySfx(buttonClickSound);
    }

    private void PlaySfx(AudioClip clip)
    {
        if (sfxSource == null || clip == null) return;

        sfxSource.PlayOneShot(clip);
    }
}