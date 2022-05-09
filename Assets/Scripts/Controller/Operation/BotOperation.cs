using UnityEngine;

namespace Game.Controller.Operation
{
    public enum Movement { WALK, JUMP, LAMP, TURN_LEFT, TURN_RIGHT };

    public abstract class BotOperation : MonoBehaviour
    {
        #region Methods
            public abstract bool IsValid ();
            public abstract void Run ();
        #endregion
    }
}
