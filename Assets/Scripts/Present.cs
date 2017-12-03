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
        const string conveyorBeltTag = "Conveyor Belt";

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
        }

        void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag(conveyorBeltTag))
            {
                conveyorBelts.Remove(collision.GetComponent<ConveyorBelt>());
                ConveyorBeltChanged();
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
