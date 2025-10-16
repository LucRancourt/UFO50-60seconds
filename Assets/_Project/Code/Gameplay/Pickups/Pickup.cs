using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(MeshRenderer))]
public class Pickup : MonoBehaviour, IInteractable
{
    // Variables
    private Rigidbody _rigidbody;
    private bool _isKinematic;
    private Collider _collider;

    private SphereCollider _interactCollider;
    [SerializeField] private float interactColliderRadius = 2.0f;

    private Camera _player;

    private Vector3 _throwDirection;
    [SerializeField] private float throwForce = 50.0f;


    // Functions
    protected virtual void Awake()
    {
        SetLayerInteractable();

        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.useGravity = true;
        _isKinematic = _rigidbody.isKinematic;

        _collider = GetComponent<Collider>();

        _interactCollider = gameObject.AddComponent<SphereCollider>();
        _interactCollider.isTrigger = true;
        _interactCollider.radius = interactColliderRadius;


        Outline outline = gameObject.AddComponent<Outline>();

        outline.OutlineMode = Outline.Mode.OutlineVisible;
        outline.OutlineColor = Color.yellow;
        outline.OutlineWidth = 10f;
    }

    private void Start()
    {
        _player = Camera.main;
    }

    public void Interact(PlayerInteract player)
    {
        if (transform.parent != player.transform)
            PickupObject();
        else
            ThrowObject();
    }

    private void PickupObject()
    {
        gameObject.layer = _player.gameObject.layer;

        _collider.isTrigger = true;

        _rigidbody.useGravity = false;
        SetKinematic(true);

        transform.parent = _player.transform;
        transform.localPosition = new Vector3(0.0f, 0.0f, _interactCollider.radius * 2.0f);
    }

    public void ThrowObject()
    {
        RemoveParent();

        SetKinematic(_isKinematic);

        SetLayerInteractable();

        _collider.isTrigger = false;

        _rigidbody.AddForce(_throwDirection * throwForce, ForceMode.Impulse);
    }

    private void SetLayerInteractable()
    {
        gameObject.layer = LayerMask.NameToLayer("Interactable");
    }

    private void SetKinematic(bool value)
    {
        _rigidbody.isKinematic = value;
    }

    private void RemoveParent()
    {
        _throwDirection = transform.parent.forward;
        
        transform.parent = null;

        _rigidbody.useGravity = true;
    }
}