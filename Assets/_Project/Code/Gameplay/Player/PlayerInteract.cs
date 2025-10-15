using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private PlayerInputActions _inputActions;

    [SerializeField] private LayerMask _interactables;
    [SerializeField] private float _interactRange = 10f;
    [SerializeField] private Transform _playerEyes;

    private IInteractable _heldObject = null;



    private void Start()
    {
        _inputActions = new PlayerInputActions();
        _inputActions.Gameplay.Enable();
        _inputActions.Gameplay.Interact.performed
            += context => TryInteract();
    }

    public void TryInteract()
    {
        if (_heldObject != null)
        {
            _heldObject.Interact();
            _heldObject = null;
            return;
        }

        RaycastHit hit;

        if (Physics.Raycast(
            _playerEyes.position,
            _playerEyes.forward, out hit,
            _interactRange,
            _interactables))
        {
            var interactable = hit.collider.GetComponent<IInteractable>();
            if (interactable != null)
            {
                interactable.Interact();
                _heldObject = interactable;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (_playerEyes == null) return;

        Gizmos.color = Color.white;
        Gizmos.DrawRay(_playerEyes.position, _playerEyes.forward * _interactRange);
    }
}