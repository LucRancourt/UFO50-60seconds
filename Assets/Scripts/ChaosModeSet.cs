using UnityEngine;
using UnityEngine.UI;

public class ChaosModeSet : MonoBehaviour
{
    [SerializeField] private Toggle setter;

    private void Start()
    {
        SetChaosMode(setter.isOn);
    }

    public void SetChaosMode(bool isOn)
    {
        PlayerPrefs.SetInt("RandomlySpawnInteractables", isOn ? 1 : 0);
    }
}
