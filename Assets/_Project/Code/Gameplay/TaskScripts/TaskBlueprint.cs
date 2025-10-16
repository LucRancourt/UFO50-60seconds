using System.Collections;
using UnityEngine;

public abstract class TaskBlueprint : MonoBehaviour
{
    [SerializeField] protected Task _linkedTask;
    [SerializeField] protected float _taskDuration;
    [SerializeField] protected bool _completesInstantly;


    private void Awake()
    {
        gameObject.layer = LayerMask.NameToLayer("Interactable");

        Outline outline = gameObject.AddComponent<Outline>();

        if (_linkedTask) _linkedTask.OnTaskCompleted += DisableOutline;

        outline.OutlineMode = Outline.Mode.OutlineVisible;
        outline.OutlineColor = Color.yellow;
        outline.OutlineWidth = 10f;
    }

    protected virtual void DisableOutline(Task task)
    {
        GetComponent<Outline>().enabled = false;
        Destroy(this);
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
