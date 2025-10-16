using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider))]
public class BusScript : MonoBehaviour
{
    [Header("Bus Settings")]
    [SerializeField] private float _driveSpeed;
    [SerializeField] private Vector3 _driveDirection;

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
            StartCoroutine(BeginWinDelay());
        }
    }

    private void Update()
    {
        if (_isDriving)
        {
            transform.Translate(_driveDirection.normalized * _driveSpeed * Time.deltaTime, Space.World);
        }
    }

    private IEnumerator BeginWinDelay()
    {
        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene(1);
    }
}
