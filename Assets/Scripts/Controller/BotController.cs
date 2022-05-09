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

            internal enum Direction { FORWARD, RIGHT, BACKWARD, LEFT };
            private float positionThreshold = 0.05f;
            private float rotationThreshold = 10f;
            private float deltaTime = 0.125f;
            private Position initialPlatformPosition;
            private Direction initialDirection;
            private Vector3 initialWorldPosition;
            private Vector3 initialWorldRotation;
        #endregion

        #region Methods
            private void Awake ()
            {
                initialPlatformPosition = currentPosition;
                initialDirection = currentDirection;
                initialWorldPosition = this.transform.position;
                initialWorldRotation = this.transform.eulerAngles;
            }

            internal void Reset ()
            {
                this.transform.position = initialWorldPosition;
                this.transform.eulerAngles = initialWorldRotation;
                currentPosition = initialPlatformPosition;
                currentDirection = initialDirection;
            }

            internal System.Collections.IEnumerator Walk (Position nextPosition, Vector3 platformWorldPosition)
            {
                while ((this.transform.position - platformWorldPosition).magnitude > positionThreshold)
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
                Vector3 currentAngles = this.transform.eulerAngles;

                while ((currentAngles - targetAngles).magnitude > rotationThreshold)
                {
                    currentAngles = Vector3.Lerp(currentAngles, targetAngles, deltaTime);
                    this.transform.rotation = Quaternion.Euler(currentAngles);
                    yield return new WaitForFixedUpdate();
                }

                this.transform.eulerAngles = targetAngles;
                currentDirection = (Direction)((int)(currentDirection + 1) % 4);
                yield return new WaitForFixedUpdate();
            }

            internal System.Collections.IEnumerator TurnLeft ()
            {
                Vector3 targetAngles = this.transform.eulerAngles - new Vector3(0, 90, 0);
                Vector3 currentAngles = this.transform.eulerAngles;
                if (currentAngles.y > 180)
                    currentAngles = this.transform.eulerAngles - Vector3.up * 360;

                while ((currentAngles - targetAngles).magnitude > rotationThreshold)
                {
                    currentAngles = Vector3.Lerp(currentAngles, targetAngles, deltaTime);
                    this.transform.rotation = Quaternion.Euler(currentAngles);
                    yield return new WaitForFixedUpdate();
                }

                Debug.Log("NO");

                this.transform.eulerAngles = targetAngles;
                currentDirection = (Direction)((int)(currentDirection + 3) % 4);
                yield return new WaitForFixedUpdate();
            }

            internal System.Collections.IEnumerator Switch (TargetPlatform targetPlatform)
            {
                targetPlatform.Switch();
                yield return new WaitForFixedUpdate();
            }

            internal System.Collections.IEnumerator Jump (Position nextPosition, Vector3 lastPlatformBlockPosition)
            {
                while ((this.transform.position - lastPlatformBlockPosition).magnitude > positionThreshold)
                {
                    this.transform.position = Vector3.Lerp(this.transform.position, lastPlatformBlockPosition, deltaTime);
                    yield return new WaitForFixedUpdate();
                }

                this.transform.position = lastPlatformBlockPosition;
                currentPosition = nextPosition;
                yield return new WaitForFixedUpdate();
            }
        #endregion
    }
}