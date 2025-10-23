using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(SoundFX))]
public class SoundFXEditor : Editor
{
    public override void OnInspectorGUI()
    {
        SoundFX soundFX = (SoundFX)target;
        SerializedObject serializedObject = new SerializedObject(soundFX);

        EditorGUILayout.PropertyField(serializedObject.FindProperty("Clips"));
        

        if (soundFX.RandomizeVolume)
        {
            soundFX.MinVolume = EditorGUILayout.Slider("Min Volume", soundFX.MinVolume, 0, 1);
            soundFX.MaxVolume = EditorGUILayout.Slider("Max Volume", soundFX.MaxVolume, 0, 1);
        }
        else
        {
            soundFX.MinVolume = EditorGUILayout.Slider("Volume", soundFX.MinVolume, 0, 1);
            soundFX.MaxVolume = soundFX.MinVolume;
        }


        if (soundFX.RandomizePitch)
        {
            soundFX.MinPitch = EditorGUILayout.Slider("Min Pitch", soundFX.MinPitch, -3, 3);
            soundFX.MaxPitch = EditorGUILayout.Slider("Max Pitch", soundFX.MaxPitch, -3, 3);
        }
        else
        {
            soundFX.MinPitch = EditorGUILayout.Slider("Pitch", soundFX.MinPitch, -3, 3);
            soundFX.MaxPitch = soundFX.MinPitch;
        }
        EditorGUILayout.Space(2);
        soundFX.RandomizeVolume = GUILayout.Toggle(soundFX.RandomizeVolume, "Randomize Volume");
        soundFX.RandomizePitch = GUILayout.Toggle(soundFX.RandomizePitch, "Randomize Pitch");


        
        //if (GUILayout.Button("Play"))
        //    soundFX.Play();


    }
}
