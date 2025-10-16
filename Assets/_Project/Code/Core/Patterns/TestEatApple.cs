using UnityEngine;
using System.Collections;

public class TestEatApple : MonoBehaviour, IInteractable
{
    //This is an example script to test the Task system

    [SerializeField] private Task _linkedTask;
    [SerializeField] private float _taskDuration;
    [SerializeField] private bool _completesInstantly;

    public void Interact(PlayerInteract player)
    {
        Debug.Log($"Interacted with {gameObject.name}");

        if (_completesInstantly)
            _linkedTask?.Complete();
        else
            StartCoroutine(DoTaskRoutine());
    }

    private IEnumerator DoTaskRoutine()
    {
        Debug.Log("eating apple");
        yield return new WaitForSeconds(_taskDuration);
        _linkedTask?.Complete();
    }
}