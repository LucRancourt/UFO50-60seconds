using UnityEngine;
using System;
using System.Collections.Generic;

public class CounterTask : TaskBlueprint, IInteractable
{
    public Action OnCompleted;

    private bool complete = false;
    [SerializeField] private List<AudioCue> audioCues;

    public void Interact(PlayerInteract player)
    {
        if (complete) return;
        complete = true;

        OnCompleted?.Invoke();

        AudioManager.Instance.PlayRandomSound(audioCues);
    }
}
