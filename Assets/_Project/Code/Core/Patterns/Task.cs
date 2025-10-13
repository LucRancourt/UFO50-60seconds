using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Task", menuName = "Task System/Task")]
public class Task : ScriptableObject
{
    public string taskName;
    public bool isCompleted;

    public event Action<Task> OnTaskCompleted;

    public void Complete()
    {
        if (isCompleted) return;
        isCompleted = true;
        Debug.Log($"Task Completed: {taskName}");
        OnTaskCompleted?.Invoke(this);
    }
}
