using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [Header("---Audio Source---")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource SFXSource;

    [Header("---Audio Clip---")]
    public AudioClip musicClip;
    public AudioClip TeleportClip;
    public AudioClip startTeleportClip;
    public AudioClip walkClip;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        musicSource.clip = musicClip;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
