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
            private float speed = 5f;

            [SerializeField]
            internal Position currentPosition;

            [SerializeField]
            internal Direction currentDirection = Direction.FORWARD;

            internal enum Direction { FORWARD, BACKWARD, LEFT, RIGHT }
        #endregion

        #region Methods
            internal System.Collections.IEnumerator Walk (Position nextPosition)
            {
                Vector3 targetPosition = BoardManager.Instance.GetPlatformPosition(nextPosition);

                while ((this.transform.position - targetPosition).magnitude > 0.05f)
                {
                    this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, 0.125f);
                    yield return new WaitForFixedUpdate();
                }

                this.transform.position = targetPosition;
                currentPosition = nextPosition;
                yield return new WaitForFixedUpdate();
            }
        #endregion
    }
}