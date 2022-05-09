using System.Collections;

namespace Game.Controller.Operation
{
    public class TurnLeftOperation : BotOperation
    {
        #region Methods
            public override bool IsValid ()
            {
                return true;
            }

            public override IEnumerator Run ()
            {
                yield return botController.TurnLeft();
            }
        #endregion
    }
}