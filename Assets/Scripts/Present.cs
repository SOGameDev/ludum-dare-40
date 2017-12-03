namespace Assets.Scripts
{
    using System.Collections.Generic;
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

        new Rigidbody2D rigidbody;

        Vector2 conveyorBeltDirection;

        float conveyorBeltSpeed;

        List<ConveyorBelt> conveyorBelts = new List<ConveyorBelt>();

        void Start()
        {
            rigidbody = GetComponent<Rigidbody2D>();
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag(conveyorBeltTag))
            {
                conveyorBelts.Add(collision.GetComponent<ConveyorBelt>());
                ConveyorBeltChanged();
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
                conveyorBelts.Remove(collision.GetComponent<ConveyorBelt>());
                ConveyorBeltChanged();
            }
            else if (collision.CompareTag(scoringDeadzoneTag))
            {
                deadzone_count--;
            }
        }

        void ConveyorBeltChanged()
        {
            conveyorBeltSpeed = 0;
            foreach (ConveyorBelt conveyorBelt in conveyorBelts)
            {
                if (conveyorBelt.Speed > conveyorBeltSpeed)
                {
                    conveyorBeltDirection = conveyorBelt.transform.right;
                    conveyorBeltSpeed = conveyorBelt.Speed;
                }
            }
        }

        void FixedUpdate()
        {
            if (conveyorBelts.Count > 0)
            {
                rigidbody.AddForce(conveyorBeltSpeed*conveyorBeltDirection*rigidbody.mass);
            }
        }
    }
}
