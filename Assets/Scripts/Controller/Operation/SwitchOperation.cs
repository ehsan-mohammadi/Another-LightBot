using System.Collections;

namespace Game.Controller.Operation
{
    using Model;

    public class SwitchOperation : BotOperation
    {
        #region Methods
            public override bool IsValid ()
            {
                return true;
            }

            public override IEnumerator Run ()
            {
                TargetPlatform targetPlatform = BoardManager.Instance.GetTargetPlatform(botController.currentPosition);

                if (targetPlatform)
                    yield return botController.Switch(targetPlatform);
            }
        #endregion
    }
}