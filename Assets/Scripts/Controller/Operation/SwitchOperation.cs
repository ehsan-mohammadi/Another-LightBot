using System.Collections;

namespace Game.Controller.Operation
{
    using Model;

    public class SwitchOperation : BotOperation
    {
        #region Variables
            TargetPlatform targetPlatform;
        #endregion

        #region Methods
            public override bool IsValid ()
            {
                targetPlatform = BoardManager.Instance.GetTargetPlatform(botController.currentPosition);

                if (targetPlatform)
                    return true;
                return false;
            }

            public override IEnumerator Run ()
            {
                if (IsValid())
                    yield return botController.Switch(targetPlatform);
            }
        #endregion
    }
}