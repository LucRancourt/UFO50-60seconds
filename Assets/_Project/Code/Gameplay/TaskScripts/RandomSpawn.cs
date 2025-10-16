using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    private void Start()
    {
        if (PlayerPrefs.GetInt("RandomlySpawnInteractables") == 0)
        {
            Destroy(this);
            return;
        }


        TaskBlueprint[] _taskBlueprints = FindObjectsByType<TaskBlueprint>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        Pickup[] _pickups = FindObjectsByType<Pickup>(FindObjectsInactive.Include, FindObjectsSortMode.None);

        List<GameObject> _interactables = new List<GameObject>();

        foreach (TaskBlueprint task in _taskBlueprints)
        {
            _interactables.Add(task.gameObject);
        }

        foreach (Pickup pickup in _pickups)
        {
            _interactables.Add(pickup.gameObject);
        }

        List<Vector3> positionList = new List<Vector3>();

        foreach (GameObject interactable in _interactables)
        {
            positionList.Add(interactable.transform.position);
        }


        for (int i = (_interactables.Count - 1); i >= 0; i--)
        {
            int index = Random.Range(0, i);
            _interactables[i].transform.position = positionList[index];
            _interactables.RemoveAt(i);
            positionList.RemoveAt(index);
        }
    }
}
