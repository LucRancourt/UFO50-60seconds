using System.Collections;
using UnityEngine;

public class DrinkCoffee : TaskBlueprint, IInteractable
{
    public void Interact(PlayerInteract player)
    {
        Debug.Log($"Interacted with Coffee Cup");
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
