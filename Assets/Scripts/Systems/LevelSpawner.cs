namespace Assets.Scripts.Systems
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    /// <summary>
    ///     Handles spawning the level.
    /// </summary>
    public class LevelSpawner : MonoBehaviour
    {
        public string level_name = "Levels/Medium";
        private void Start()
        {
            GameObject levelPrefab = Resources.Load( level_name ) as GameObject;
            Instantiate(levelPrefab);
        }

        public void LoadScene( string scene_name )
        {
          SceneManager.LoadScene( scene_name );
        }
    }
}
