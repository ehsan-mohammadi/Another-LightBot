namespace Game.Controller.Operation
{
    public class WalkOperation : BotOperation
    {
        #region Methods
            public override bool IsValid ()
            {
                return true;
            }

            public override void Run ()
            {
                UnityEngine.Debug.Log("HEY!");
            }
        #endregion
    }
}