using UnityEngine;

public class SoundFXManager : MonoBehaviour
{
    public static SoundFXManager Instance;

    [SerializeField] AudioSource soundFXObject;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;

    }

    public void PlaySoundFXClip(AudioClip clip, Transform spawnTransform, float volume, float pitch)
    {
        AudioSource audiosource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);

        audiosource.clip = clip;

        audiosource.volume = volume;

        audiosource.pitch = pitch;

        audiosource.Play();

        float clipLength = audiosource.clip.length;

        Destroy(audiosource.gameObject, clipLength);

    }
}
