using UnityEngine;
using System.Collections;

public class WaitTask : TaskBlueprint, IInteractable
{
    public void Interact(PlayerInteract player)
    {
        if (_completesInstantly)
            _linkedTask?.Complete();
        else
            StartCoroutine(DoTaskRoutine());
    }

    public override IEnumerator DoTaskRoutine()
    {
        return base.DoTaskRoutine();
    }
}
