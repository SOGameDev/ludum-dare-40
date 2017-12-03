namespace Assets.Scripts
{
    using UnityEngine;

    /// <summary>
    ///     Snow fall effect.
    /// </summary>
    public class Snow : MonoBehaviour
    {
        static Snow snowInstance;

        void Awake()
        {
            if (snowInstance == null)
            {
                DontDestroyOnLoad(this);
            }
            else
            {
                
            }
        }
    }
}
