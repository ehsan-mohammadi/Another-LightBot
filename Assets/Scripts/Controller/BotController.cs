using UnityEngine;

namespace Game.Controller
{
    using Model;

    public class BotController : MonoBehaviour
    {
        #region Variables
            [SerializeField]
            private float speed = 5f;

            [SerializeField]
            private Position currentPosition;

            [SerializeField]
            private Direction currentDirection = Direction.FORWARD;

            private enum Direction { FORWARD, BACKWARD, LEFT, RIGHT }
        #endregion

        #region Methods
            private void Update ()
            {
                
            }

            private void Move ()
            {

            }
        #endregion
    }
}