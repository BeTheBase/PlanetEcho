using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ruben
{
    public class PrefabSpawner : MonoBehaviour
    {
        [SerializeField] private int maxPrefabs = 0;
        [SerializeField] private GameObject prefab;
        private List<Transform> prefabList = new List<Transform>();

        private void Start()
        {
            BoxCollider spawnArea = GetComponent<BoxCollider>();
            for (int i = 0; i < maxPrefabs; i++)
            {
                Transform newPrefab = Instantiate(prefab, transform).transform;
                prefabList.Add(newPrefab);
                newPrefab.position = RandomPointInBounds(spawnArea.bounds);
                newPrefab.GetComponent<Animator>().Play("RandomMovementanim", 0, Random.value);
            }
            spawnArea.enabled = false;
        }

        private Vector3 RandomPointInBounds(Bounds bounds)
        {
            return new Vector3(
                Random.Range(bounds.min.x, bounds.max.x),
                Random.Range(bounds.min.y, bounds.max.y),
                Random.Range(bounds.min.z, bounds.max.z)
            );
        }
    }
}
