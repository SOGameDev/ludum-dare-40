namespace Assets.Scripts
{
    using UnityEngine;
    using System.Collections;

    /// <summary>
    ///     Conveyor belt.
    /// </summary>
    public class ConveyorBelt : MonoBehaviour
    {
        [SerializeField]
        float speed = 5;

        /// <summary>
        ///     The speed that this conveyor belt is moving at.
        /// </summary>
        /// <value>The speed.</value>
        public float Speed
        {
            get { return speed; }
            set { speed = value; }
        }
    }
}
