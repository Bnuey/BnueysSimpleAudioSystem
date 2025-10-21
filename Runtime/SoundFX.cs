using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SoundFX : ScriptableObject
{
    [Tooltip("Random AudioClip Chosen From List")]
    public List<AudioClip> Clips = new List<AudioClip>();

    public float Volume;

    [Tooltip("Random Pitch Between Min and Max, Set Both The Same For Consistent Pitch")]
    public float MinPitch, MaxPitch;

    public void Play(Transform transform)
    {
        var randClip = Random.Range(0, Clips.Count);
        var randPitch = Random.Range(MinPitch, MaxPitch);

        SoundFXManager.Instance.PlaySoundFXClip(Clips[randClip], transform, Volume, randPitch);
    }
}
