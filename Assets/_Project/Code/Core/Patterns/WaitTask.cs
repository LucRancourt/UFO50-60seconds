using UnityEngine;
using System.Collections;

public class WaitTask : TaskBlueprint, IInteractable
{
    [SerializeField] private AudioCue audioCue;

    private bool isCompleted = false;

    public void Interact(PlayerInteract player)
    {
        if (isCompleted) return;
        isCompleted = true;

        if (_completesInstantly)
            _linkedTask?.Complete();
        else
            StartCoroutine(DoTaskRoutine());

        if (audioCue) AudioManager.Instance.PlaySound(audioCue);
    }

    public override IEnumerator DoTaskRoutine()
    {
        return base.DoTaskRoutine();
    }
}
