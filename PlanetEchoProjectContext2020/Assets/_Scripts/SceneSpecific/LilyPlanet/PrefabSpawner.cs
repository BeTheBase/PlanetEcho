using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ruben
{
    public class PrefabSpawner : MonoBehaviour
    {
        public float spawnTimer = 4f;
        [SerializeField] private int initialPrefabs = 0;
        [SerializeField] private int maxPrefabs = 40;
        [SerializeField] private GameObject prefab;

        private float timer = 0f;
        private Bounds boundingBox;
        private List<Transform> prefabList = new List<Transform>();

        private void Start()
        {
            boundingBox = GetComponent<BoxCollider>().bounds;
            GetComponent<BoxCollider>().enabled = false;

            for (int i = 0; i < initialPrefabs; i++)
            {
                prefabList.Add(SpawnPrefab());
            }
        }

        private void Update()
        {
            timer += Time.deltaTime;
            if (timer >= spawnTimer)
            {
                timer = 0;
                if (prefabList.Count < maxPrefabs)
                {
                    SpawnPrefab();
                }
            }
        }

        private Transform SpawnPrefab()
        {
            Transform newPrefab = Instantiate(prefab, transform).transform;
            newPrefab.position = RandomPointInBounds(boundingBox);
            newPrefab.localEulerAngles = new Vector3(Random.Range(0, 359), Random.Range(0, 359), Random.Range(0, 359));
            newPrefab.GetComponent<Animator>().Play("RandomMovementanim", 0, Random.value);

            PlanetLily.Instance.AddSpawnedWooshie();

            return newPrefab;
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
