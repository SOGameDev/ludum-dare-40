namespace Assets.Scripts
{
    using UnityEngine;

    /// <summary>
    ///     Misc. present logic.
    /// </summary>
    [RequireComponent(typeof(Rigidbody2D))]
    public class Present : MonoBehaviour
    {
        const string conveyorBeltTag = "Conveyor Belt";

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
        }

        void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag(conveyorBeltTag))
            {
                onConveyorBelt = false;
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
