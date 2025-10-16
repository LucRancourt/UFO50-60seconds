using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Task", menuName = "Task System/Task")]
public class Task : ScriptableObject
{
    public TaskType taskName;

    public event Action<Task> OnTaskCompleted;

    public void Complete()
    {
        Debug.Log($"Task Completed: {taskName}");
        OnTaskCompleted?.Invoke(this);
    }
}
