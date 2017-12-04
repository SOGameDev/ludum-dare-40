namespace Assets.Scripts
{
    using UnityEngine;

    /// <summary>
    ///     Snow fall effect.
    /// </summary>
    public class Snow : MonoBehaviour
    {
        static Snow snowInstance;

        [SerializeField]
        RectTransform snowflakePrefab;

        float lastTime;

        float delay;

        [SerializeField]
        float minDelay = 0.5f;

        [SerializeField]
        float maxDelay = 2.0f;

        Transform canvas;

        const string guiTag = "GUI";

        void Awake()
        {
            if (snowInstance == null)
            {
                DontDestroyOnLoad(this);
                snowInstance = this;
            }
            else
            {
                DestroyObject(gameObject);
            }

            delay = Random.Range(minDelay, maxDelay);

            canvas = GameObject.FindWithTag(guiTag).transform;
        }

        void Update()
        {
            if (Time.time >= lastTime + delay)
            {
                Instantiate(snowflakePrefab, new Vector3(Random.Range(-1000, 1000), 500), Quaternion.Euler(0, 0, Random.Range(0, 360.0f)), canvas);
                lastTime = Time.time;
                delay = Random.Range(minDelay, maxDelay);
            }
        }
    }
}
