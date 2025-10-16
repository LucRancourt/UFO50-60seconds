using System.Collections.Generic;
using UnityEngine;

public class CounterTaskManager : TaskBlueprint
{
    [SerializeField] private List<CounterTask> objects;
    [SerializeField] private int numberRequired;
    private int _totalTasksCompleted;

    private void Start()
    {
        _totalTasksCompleted = 0;

        foreach (CounterTask task in objects)
        {
            task.OnCompleted += IncreaseCount;
        }
    }

    public void IncreaseCount()
    {
        _totalTasksCompleted++;
        Debug.Log(_totalTasksCompleted);

        
        if (_totalTasksCompleted == numberRequired)
            _linkedTask?.Complete();
    }
}
