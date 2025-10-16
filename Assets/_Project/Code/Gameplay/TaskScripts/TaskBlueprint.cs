using System.Collections;
using UnityEngine;

public abstract class TaskBlueprint : MonoBehaviour
{
    [SerializeField] protected Task _linkedTask;
    [SerializeField] protected float _taskDuration;
    [SerializeField] protected bool _completesInstantly;

    public virtual IEnumerator DoTaskRoutine()
    {
        if (_completesInstantly)
        {
            _linkedTask?.Complete();
            yield break;
        }

        yield return new WaitForSeconds(_taskDuration);
        _linkedTask?.Complete();
    }
}
