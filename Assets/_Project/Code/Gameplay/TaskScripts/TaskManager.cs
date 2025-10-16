using UnityEngine;
using System.Collections.Generic;
using _Project.Code.Core.Patterns;
using TMPro;

public class TaskManager : Singleton<TaskManager>
{
    [SerializeField] private List<Task> _tasks = new();
    [SerializeField] private TextMeshProUGUI _taskList;
    private List<string> _taskNames = new();

    private void OnEnable()
    {
        foreach (var task in _tasks)
        {
            task.OnTaskCompleted += HandleTaskCompleted;
        }

        foreach (var task in _tasks)
        {
            _taskNames.Add(task.taskName.ToString());
        }

        DisplayTasks();
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
        if (_tasks.Contains(completedTask))
        {
            _tasks.Remove(completedTask);
            Debug.Log($"Remaining tasks: {_tasks.Count}");
        }
        else
        {

        }
    }

    private void DisplayTasks()
    {
        foreach (var taskName in _taskNames)
        {
            _taskList.text += $"> {taskName} <\n";
        }
    }
}