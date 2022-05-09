namespace Game.Controller.Operation
{
    public enum Movement { WALK, JUMP, TURN_LEFT, TURN_RIGHT };

    public abstract class BotOperation
    {
        #region Methods
            public abstract bool IsValid ();
            public abstract void Run ();
        #endregion
    }
}
