using System.Collections.Generic;
using UnityEngine;

public class CounterTask : TaskBlueprint
{
    [SerializeField] private List<TaskBlueprint> objects;
    [SerializeField] private int numberRequired;
    private int _totalObjects;

    private void Start()
    {
        _totalObjects = objects.Count;

        if (_totalObjects - numberRequired < 0)
            numberRequired = _totalObjects;
    }

    public void DecreaseCount(TaskBlueprint interacted)
    {
        objects.Remove(interacted);

        if (objects.Count == _totalObjects - numberRequired)
            _linkedTask?.Complete();
    }
}
