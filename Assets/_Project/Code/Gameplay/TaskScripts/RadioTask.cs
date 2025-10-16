using UnityEngine;

public class RadioTask : TaskBlueprint, IInteractable
{
    private bool isOn = true;

    public void Interact(PlayerInteract player)
    {
        _linkedTask?.Complete();

        isOn = !isOn;

        if (isOn)
            AudioManager.Instance.ResumeMusic();
        else
            AudioManager.Instance.StopMusic();
    }
}
