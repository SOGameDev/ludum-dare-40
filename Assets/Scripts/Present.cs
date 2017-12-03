namespace Assets.Scripts
{
    using UnityEngine;

    /// <summary>
    ///     Misc. present logic.
    /// </summary>
    [RequireComponent(typeof(Rigidbody2D))]
    public class Present : MonoBehaviour
    {
        const string conveyorBeltTag    = "Conveyor Belt";
        const string scoringDeadzoneTag = "Scoring Deadzone";

        public int deadzone_count = 0;

        bool onConveyorBelt;

        new Rigidbody2D rigidbody;

        Vector2 conveyorBeltDirection;

        float conveyorBeltSpeed;

        void Start()
        {
            rigidbody = GetComponent<Rigidbody2D>();
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag(conveyorBeltTag))
            {
                onConveyorBelt = true;
                conveyorBeltDirection = collision.transform.right;
                conveyorBeltSpeed = collision.GetComponent<ConveyorBelt>().Speed;
            }
            else if ( collision.CompareTag( scoringDeadzoneTag ) )
            {
                deadzone_count ++;
            }
        }

        void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag(conveyorBeltTag))
            {
                onConveyorBelt = false;
            }
            else if ( collision.CompareTag( scoringDeadzoneTag ) )
            {
                deadzone_count --;
            }
        }

        void FixedUpdate()
        {
            if (onConveyorBelt)
            {
                rigidbody.AddForce(conveyorBeltSpeed*conveyorBeltDirection*rigidbody.mass);
            }
        }
    }
}
