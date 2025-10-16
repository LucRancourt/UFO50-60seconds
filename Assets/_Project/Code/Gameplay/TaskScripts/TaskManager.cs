using UnityEngine;
using System.Collections.Generic;
using _Project.Code.Core.Patterns;
using TMPro;

public class TaskManager : Singleton<TaskManager>
{
    [SerializeField] private List<Task> _tasks = new();
    [SerializeField] private TextMeshProUGUI _taskList;
    private List<string> _taskNames = new();

    private HashSet<Task> _completedTasks = new();

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
        _completedTasks.Add(completedTask);

        DisplayTasks();
    }
    private void DisplayTasks()
    {
        _taskList.text = "";

        foreach (var task in _tasks)
        {
            bool isCompleted = _completedTasks.Contains(task);
            string checkmark = isCompleted ? "*" : "";
            _taskList.text += $"> {task.taskName} {checkmark}\n";
        }
    }
}