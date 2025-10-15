using UnityEngine;

[CreateAssetMenu(fileName = "NewAudioCue", menuName = "Audio/Audio Cue")]
public class AudioCue : ScriptableObject
{
    [field: SerializeField] public AudioClip Clip { get; private set; }
    [field: SerializeField, Range(0.0f, 1.0f)] public float Volume { get; private set; } = 1.0f;
    [field: SerializeField, Range(0.1f, 5.0f)] public float Pitch { get; private set; } = 1.0f;
}