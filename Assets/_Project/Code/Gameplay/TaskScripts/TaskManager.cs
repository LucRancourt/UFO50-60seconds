using UnityEngine;
using System.Collections.Generic;
using _Project.Code.Core.Patterns;

public class TaskManager : Singleton<TaskManager>
{
    [SerializeField] private List<Task> _tasks = new();

    private void OnEnable()
    {
        foreach (var task in _tasks)
        {
            task.OnTaskCompleted += HandleTaskCompleted;
        }
    }

    private void OnDisable()
    {
        foreach (var task in _tasks)
        {
            task.OnTaskCompleted -= HandleTaskCompleted;
        }
    }

    private void HandleTaskCompleted(Task completedTask)
    {
        Debug.Log($"Task has been completed: {completedTask.taskName}");
    }
}
