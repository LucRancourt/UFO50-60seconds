using UnityEngine;
using _Project.Code.Gameplay.Triggers;

public class TaskTriggerZone : TriggerZone
{
    // Variables
    [SerializeField] private Task task;
    [SerializeField] private Pickup objectRequired;
    [SerializeField] private float durationRequired;
    private float _totalDurationRequired;
    [SerializeField] private bool resetTimeOnExit = false;
    private bool _isBeingCompleted;
    [SerializeField] private AudioCue audioCue;
    private AudioSource _source;


    // Functions
    protected override void Awake()
    {
        base.Awake();

        _totalDurationRequired = durationRequired;
    }

    protected override void OnZoneEntered(GameObject obj)
    {
        if (obj.TryGetComponent(out Pickup pickup))
        {
            if (pickup == objectRequired)
            {
                _isBeingCompleted = true;
                _source = AudioManager.Instance.PlaySoundReturn(audioCue);
            }
        }
    }

    protected override void OnZoneExited(GameObject obj)
    {
        if (obj.TryGetComponent(out Pickup pickup))
        {
            if (pickup == objectRequired)
            {
                _isBeingCompleted = false;

                _source.Stop();

                if (resetTimeOnExit) durationRequired = _totalDurationRequired;
            }
        }
    }

    private void Update()
    {
        if (_isBeingCompleted) durationRequired -= Time.deltaTime;

        if (durationRequired <= 0.0f)
            task.Complete();
    }
}
