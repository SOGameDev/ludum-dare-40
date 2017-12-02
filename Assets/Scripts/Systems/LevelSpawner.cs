namespace Assets.Scripts.Systems
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    ///     Handles spawning the level.
    /// </summary>
    public class LevelSpawner : MonoBehaviour
    {
        private void Start()
        {
            GameObject levelPrefab = Resources.Load("Levels/Medium") as GameObject;
            Instantiate(levelPrefab);
        }
    }
}