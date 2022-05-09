using System.Collections;

namespace Game.Controller.Operation
{
    using Model;

    public class JumpOperation : BotOperation
    {
        #region Variables
            private Position nextPosition;
        #endregion

        #region Methods
            public override bool IsValid ()
            {
                nextPosition = botController.currentPosition;

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

                return BoardManager.Instance.PlatformIsExists(nextPosition);
            }

            public override IEnumerator Run ()
            {
                if (IsValid())
                {
                    Platform currentPlatform = BoardManager.Instance.GetPlatform(botController.currentPosition);
                    Platform nextPlatform = BoardManager.Instance.GetPlatform(nextPosition);

                    if ((nextPlatform.Height - currentPlatform.Height == 1) 
                        || (currentPlatform.Height - nextPlatform.Height > 0))
                        yield return botController.Jump(nextPosition, nextPlatform.lastBlock.transform.position);
                }
            }
        #endregion
    }
}