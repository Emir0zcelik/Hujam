using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceSpawner : MonoBehaviour
{
    [SerializeField] private List<Resources> _resourcePrefabList;


    public void SpawnResources()
    {
        int random = Random.Range(0, _resourcePrefabList.Count);

        Resources resource = Instantiate(_resourcePrefabList[random], Vector3.zero, Quaternion.identity);

        resource.resourceType = (ResourceType)random + 1;
    }
}
