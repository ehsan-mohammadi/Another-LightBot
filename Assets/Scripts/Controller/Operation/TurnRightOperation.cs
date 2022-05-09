using System.Collections;

namespace Game.Controller.Operation
{
    public class TurnRightOperation : BotOperation
    {
        #region Methods
            public override bool IsValid ()
            {
                return true;
            }

            public override IEnumerator Run ()
            {
                yield return botController.TurnRight();
            }
        #endregion
    }
}