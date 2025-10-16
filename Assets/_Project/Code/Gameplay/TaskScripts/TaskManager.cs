using UnityEngine;
using System.Collections.Generic;
using _Project.Code.Core.Patterns;
using TMPro;

public class TaskManager : MonoBehaviour
{
    [SerializeField] private List<Task> _tasks = new();
    [SerializeField] private TextMeshProUGUI _taskList;

    private HashSet<Task> _completedTasks = new();

    private void Start()
    {
        foreach (var task in _tasks)
        {
            task.OnTaskCompleted += HandleTaskCompleted;
            task.Reset();
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
        ScoreManager.Instance.UpdateScore();
        DisplayTasks();
    }

    private void DisplayTasks()
    {
        _taskList.text = "";

        foreach (var task in _tasks)
        {
            bool isCompleted = _completedTasks.Contains(task);
            string strikeThroughStart = isCompleted ? "<s>" : "";
            string strikeThroughEnd = isCompleted ? "</s>" : "";

            _taskList.text += $"> {strikeThroughStart} {task.taskName} {strikeThroughEnd}\n";
        }
    }
}