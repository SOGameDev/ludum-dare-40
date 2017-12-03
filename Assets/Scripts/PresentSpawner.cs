namespace Assets.Scripts
{
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    ///     Spawns presents. This is the present factory. The doorway to Santa's Workshop. The exit pipe of all the wonder and joy that elvish crafters...  Craft.
    /// </summary>
    public class PresentSpawner : MonoBehaviour
    {
        [SerializeField]
        List<Present> presentPrefabs;

        [SerializeField]
        float minSpawnTime = 0.5f;

        [SerializeField]
        float maxSpawnTime = 1.0f;

        float lastSpawnTime;

        float spawnTime;

        void Start()
        {
            lastSpawnTime = Time.time;
            spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
        }

        void Update()
        {
            if (presentPrefabs.Count <= 0) return;

            if (Time.time >= lastSpawnTime + spawnTime)
            {
                int presentIndex = Random.Range(0, presentPrefabs.Count - 1);
                Instantiate(presentPrefabs[presentIndex], transform.position, Quaternion.Euler(0, 0, Random.Range(0.0f, 360.0f)));
                lastSpawnTime = Time.time;
            }
        }
    }
}
