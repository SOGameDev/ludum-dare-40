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
        Snowflake snowflakePrefab;

        float lastTime;

        float delay;

        [SerializeField]
        float minDelay = 0.5f;

        [SerializeField]
        float maxDelay = 2.0f;

        RectTransform canvas;

        const string snowCanvasTag = "Snow Canvas";

        [SerializeField]
        float minScale = 0.01f;

        [SerializeField]
        float maxScale = 0.25f;

        [SerializeField]
        float angleRange = 20.0f;

        [SerializeField]
        float minSpeed = 5.0f;

        [SerializeField]
        float maxSpeed = 50.0f;

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
            canvas = GameObject.FindGameObjectWithTag(snowCanvasTag).GetComponent<RectTransform>();
        }

        void Update()
        {
            if (Time.time >= lastTime + delay)
            {
                Snowflake snowflake = Instantiate(snowflakePrefab, Vector3.zero, Quaternion.Euler(0, 0, Random.Range(0, 360.0f)), canvas);
                snowflake.canvas = canvas;
                float minAngle = 270.0f - angleRange/2;
                float maxAngle = minAngle + angleRange;
                float angle = Random.Range(minAngle, maxAngle)*Mathf.Deg2Rad;
                float scale = Random.Range(minScale, maxScale);
                float speed = Mathf.Lerp(minSpeed, maxSpeed, scale/(maxScale - minScale));
                snowflake.velocity = speed*new Vector3(Mathf.Cos(angle), Mathf.Sin(angle));
                RectTransform snowflakeRectTransform = snowflake.GetComponent<RectTransform>();
                snowflakeRectTransform.localScale = new Vector3(scale, scale, 1.0f);
                snowflakeRectTransform.anchoredPosition = new Vector3(Random.Range(canvas.rect.xMin, canvas.rect.xMax), canvas.rect.yMax + snowflakeRectTransform.rect.height*scale);
                lastTime = Time.time;
                delay = Random.Range(minDelay, maxDelay);
            }
        }
    }
}
