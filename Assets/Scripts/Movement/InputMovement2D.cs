using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zombaldro.Movement
{
    [AddComponentMenu("Zombaldro/Movement/Input Movement2D")]
    [RequireComponent(typeof(Rigidbody2D))]
    public class InputMovement2D : MonoBehaviour
    {
        #region Serialized Fields

        public float maxMovementSpeed = 1;
        public float accelerationTime;
        public float decelerationTime;

        public string horizontalAxis = "Horizontal";
        public string verticalAxis = "Vertical";

        public Rigidbody2D rigidbody;

        #endregion

        #region Unity Methods

        void FixedUpdate()
        {
            float oneOverAccelerationTime = accelerationTime != 0 ? 1 / accelerationTime : 0;
            float oneOverDecelerationTime = decelerationTime != 0 ? 1 / decelerationTime : 0;

            float horizontal = Input.GetAxisRaw(horizontalAxis);
            float vertical = Input.GetAxisRaw(verticalAxis);

            Vector2 velocityDelta = Vector2.zero;
            Vector2 previousVelocity = rigidbody.velocity;

            if (horizontal != 0)
            {
                velocityDelta.x = Mathf.Sign(horizontal) * oneOverAccelerationTime;
            }
            else if (previousVelocity.x != 0)
            {
                velocityDelta.x = -Mathf.Sign(previousVelocity.x) * oneOverDecelerationTime;
            }

            if (vertical != 0)
            {
                velocityDelta.y = Mathf.Sign(vertical) * oneOverAccelerationTime;
            }
            else if (previousVelocity.y != 0)
            {
                velocityDelta.y = -Mathf.Sign(previousVelocity.y) / decelerationTime;
            }

            float threshold = Mathf.Max(oneOverDecelerationTime, oneOverDecelerationTime) * Time.deltaTime * maxMovementSpeed;
            Vector2 newVelocity = previousVelocity + velocityDelta * Time.deltaTime * maxMovementSpeed;

            float length = newVelocity.magnitude;
            length = Mathf.Abs(length) >= threshold ? length : 0;
            newVelocity.Normalize();

            rigidbody.velocity = newVelocity * Mathf.Min(length, maxMovementSpeed);
        }

        #endregion
    }
}