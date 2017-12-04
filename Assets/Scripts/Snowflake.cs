namespace Assets.Scripts
{
    using UnityEngine;

    /// <summary>
    ///     Moves a snowflake.
    /// </summary>
    public class Snowflake : MonoBehaviour
    {
        /// <summary>
        ///     The canvas that this snowflake is in.
        /// </summary>
        [HideInInspector]
        public RectTransform canvas;
        
        /// <summary>
        ///     How fast and which direction this snowflake is moving in.
        /// </summary>
        public Vector3 velocity;

        RectTransform rectTransform;

        private void Start()
        {
            rectTransform = GetComponent<RectTransform>();
        }

        private void FixedUpdate()
        {
            transform.position += velocity*Time.deltaTime;
        }

        private void Update()
        {
            if (!canvas) return;

            if (rectTransform.anchoredPosition.y < canvas.rect.yMin)
            {
                Destroy(gameObject);
            }
        }
    }
}