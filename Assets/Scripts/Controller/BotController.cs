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
            private Vector3 initialWorldRotation;
        #endregion

        #region Methods
            private void Awake ()
            {
                initialPlatformPosition = currentPosition;
                initialWorldPosition = this.transform.position;
                initialWorldRotation = this.transform.eulerAngles;
            }

            internal void Reset ()
            {
                this.transform.position = initialWorldPosition;
                this.transform.eulerAngles = initialWorldRotation;
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

            internal System.Collections.IEnumerator TurnRight ()
            {
                Vector3 targetAngles = this.transform.eulerAngles + new Vector3(0, 90, 0);
                while ((this.transform.eulerAngles - targetAngles).magnitude > threshold)
                {
                    this.transform.eulerAngles = Vector3.Lerp(this.transform.eulerAngles, targetAngles, deltaTime);
                    yield return new WaitForFixedUpdate();
                }

                this.transform.eulerAngles = targetAngles;
                yield return new WaitForFixedUpdate();
            }

            internal System.Collections.IEnumerator TurnLeft ()
            {
                Vector3 targetAngles = this.transform.eulerAngles - new Vector3(0, 90, 0);
                while ((this.transform.eulerAngles - targetAngles).magnitude > threshold)
                {
                    this.transform.eulerAngles = Vector3.Lerp(this.transform.eulerAngles, targetAngles, deltaTime);
                    yield return new WaitForFixedUpdate();
                }

                this.transform.eulerAngles = targetAngles;
                yield return new WaitForFixedUpdate();
            }
        #endregion
    }
}