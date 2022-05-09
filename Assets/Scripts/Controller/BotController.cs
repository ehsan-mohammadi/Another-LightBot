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
            private Position currentPosition;

            [SerializeField]
            private Direction currentDirection = Direction.FORWARD;

            private List<BotOperation> operations;

            private enum Direction { FORWARD, BACKWARD, LEFT, RIGHT }
        #endregion

        #region Methods
            private void Start ()
            {
                operations = new List<BotOperation>();
                operations.Add(new WalkOperation());
                RunOperation(operations[0]);
            }

            private void RunOperation (BotOperation botOperation)
            {
                botOperation.Run();
            }
        #endregion
    }
}