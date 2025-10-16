using UnityEngine;

[RequireComponent(typeof(Collider))]
public class BusScript : MonoBehaviour
{
    [Header("Bus Settings")]
    [SerializeField] private float _driveSpeed = 5f;
    [SerializeField] private Vector3 _driveDirection = Vector3.forward;

    [Header("References")]
    [SerializeField] private string _playerTag = "Player";

    private bool _isDriving = false;
    private Transform _playerTransform;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_playerTag))
        {
            _playerTransform = other.transform;

            _playerTransform.SetParent(transform);

            var controller = _playerTransform.GetComponent<CharacterController>();
            if (controller) controller.enabled = false;

            _isDriving = true;
        }
    }

    private void Update()
    {
        if (_isDriving)
        {
            transform.Translate(_driveDirection.normalized * _driveSpeed * Time.deltaTime, Space.World);
        }
    }
}
