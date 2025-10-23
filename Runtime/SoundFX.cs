using System;
using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;

[CreateAssetMenu]
public class SoundFX : ScriptableObject
{
    [Tooltip("Random AudioClip Chosen From List")]
    public List<AudioClip> Clips = new List<AudioClip>();

    public float Volume = 1;

    [Tooltip("Random Pitch Between Min and Max, Set Both The Same For Consistent Pitch")]
    public float MinPitch = 1, MaxPitch = 1;
    
    
    [Tooltip("Random Volume Between Min and Max")]
    public float MinVolume = 1, MaxVolume = 1;

    public bool RandomizeVolume;
    public bool RandomizePitch = true;
#nullable enable
    public void Play(Transform? transform = null, int? index = -1, float? volume = 1)
    {
        var clipPitch = GetPitch(MinPitch, MaxPitch);
        var clipIndex = GetSoundFXClip(index ?? -1);
        var clipVolume = GetVolume(volume ?? -1);

        PlaySoundFXClip(Clips[clipIndex], clipVolume, clipVolume, spawnTransform: transform ?? null);
    }

    public void PlaySoundFXClip(AudioClip clip, float clipVolume, float clipPitch, Transform? spawnTransform = null)
    {
        var position = Vector3.zero;
        if (spawnTransform != null) position = spawnTransform.position;

        AudioSource audiosource = Instantiate(Resources.Load<AudioSource>("SoundFXObject"), position, Quaternion.identity);

        audiosource.clip = clip;

        audiosource.volume = clipVolume;

        audiosource.pitch = clipPitch;

        audiosource.Play();

        float clipLength = audiosource.clip.length;

        Destroy(audiosource.gameObject, clipLength);

    }

    int GetSoundFXClip(int index)
    {
        if (index == -1)
            return Random.Range(0, Clips.Count);

        return 0;
    }

    float GetPitch(float min, float max)
    {
        if (RandomizePitch)
            return Random.Range(min, max);
        else
            return MinPitch;
    }

    float GetVolume(float volume)
    {
        if (RandomizeVolume)
            return Random.Range(MinVolume, MaxVolume);

        if (volume == -1)
            return Volume;
        return volume;
    }
}
