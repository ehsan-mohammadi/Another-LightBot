using UnityEngine;
using System.Collections.Generic;

namespace Game.Controller
{
    using Model;
    using Operation;

    public class BotController : MonoBehaviour
    {
        #region Variables
            [SerializeField]
            internal Position currentPosition;

            [SerializeField]
            internal Direction currentDirection = Direction.FORWARD;

            internal enum Direction { FORWARD, BACKWARD, LEFT, RIGHT };
            private float threshold = 0.05f;
            private float deltaTime = 0.125f;
            private Position initialPlatformPosition;
            private Vector3 initialWorldPosition;
        #endregion

        #region Methods
            private void Awake ()
            {
                initialPlatformPosition = currentPosition;
                initialWorldPosition = this.transform.position;
            }

            internal void Reset ()
            {
                this.transform.position = initialWorldPosition;
                currentPosition = initialPlatformPosition;
            }

            internal System.Collections.IEnumerator Walk (Position nextPosition, Vector3 platformWorldPosition)
            {
                while ((this.transform.position - platformWorldPosition).magnitude > threshold)
                {
                    this.transform.position = Vector3.Lerp(this.transform.position, platformWorldPosition, deltaTime);
                    yield return new WaitForFixedUpdate();
                }

                this.transform.position = platformWorldPosition;
                currentPosition = nextPosition;
                yield return new WaitForFixedUpdate();
            }
        #endregion
    }
}