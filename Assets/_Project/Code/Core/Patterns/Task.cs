using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Task", menuName = "Task System/Task")]
public class Task : ScriptableObject
{
    public TaskType taskName;
    public AudioCue taskCompleteAudioCue;
    public event Action<Task> OnTaskCompleted;
    private bool isCompleted = false;

    public void Complete()
    {
        if (isCompleted) return;
        isCompleted = true;
        //Debug.Log($"Task Completed: {taskName}");
        AudioManager.Instance.PlaySound(taskCompleteAudioCue);
        OnTaskCompleted?.Invoke(this);
    }

    public void Reset()
    {
        isCompleted = false;
    }
}
