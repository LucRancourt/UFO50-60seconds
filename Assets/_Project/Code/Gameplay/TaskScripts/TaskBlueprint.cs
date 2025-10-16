using System.Collections;
using UnityEngine;

public abstract class TaskBlueprint : MonoBehaviour
{
    [SerializeField] protected Task _linkedTask;
    [SerializeField] protected float _taskDuration;
    [SerializeField] protected bool _completesInstantly;

    private void Awake()
    {
        _linkedTask.OnTaskCompleted += DisableOutline;

        Outline outline = gameObject.AddComponent<Outline>();

        outline.OutlineMode = Outline.Mode.OutlineVisible;
        outline.OutlineColor = Color.yellow;
        outline.OutlineWidth = 10f;
    }

    private void DisableOutline(Task task)
    {
        GetComponent<Outline>().enabled = false;
    }

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
