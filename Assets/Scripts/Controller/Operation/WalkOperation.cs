using System.Collections;

namespace Game.Controller.Operation
{
    using Model;

    public class WalkOperation : BotOperation
    {
        #region Methods
            public override bool IsValid ()
            {
                return true;
            }

            public override IEnumerator Run ()
            {
                Position nextPosition = botController.currentPosition;

                switch (botController.currentDirection)
                {
                    case BotController.Direction.FORWARD:
                        nextPosition += new Position(0, 1);
                        break;
                    case BotController.Direction.BACKWARD:
                        nextPosition += new Position(0, -1);
                        break;
                    case BotController.Direction.LEFT:
                        nextPosition += new Position(-1, 0);
                        break;
                    case BotController.Direction.RIGHT:
                        nextPosition += new Position(1, 0);
                        break;
                    default:
                        break;
                }

                if (BoardManager.Instance.IsPlatformExists(nextPosition))
                {
                    Platform currentPlatform = BoardManager.Instance.GetPlatform(botController.currentPosition);
                    Platform nextPlatform = BoardManager.Instance.GetPlatform(nextPosition);

                    if (currentPlatform.Height == nextPlatform.Height)
                        yield return botController.Walk(nextPosition
                            , BoardManager.Instance.GetPlatformWorldPosition(nextPosition));
                }
            }
        #endregion
    }
}