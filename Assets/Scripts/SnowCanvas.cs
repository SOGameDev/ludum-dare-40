namespace Assets.Scripts
{
    using UnityEngine;

    /// <summary>
    ///     Snow canvas.
    /// </summary>
    public class SnowCanvas : MonoBehaviour
    {
        static SnowCanvas objectInstance;

        void Awake()
        {
            if (objectInstance == null)
            {
                DontDestroyOnLoad(this);
                objectInstance = this;
            }
            else
            {
                DestroyObject(gameObject);
            }
        }
    }
}