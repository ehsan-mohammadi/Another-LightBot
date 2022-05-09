using UnityEngine;
using System.Collections;

namespace Game.Controller.Operation
{
    public enum Movement { WALK, JUMP, SWITCH, TURN_LEFT, TURN_RIGHT };

    public abstract class BotOperation : MonoBehaviour
    {
        #region Variables
            protected BotController botController;
        #endregion

        #region Methods
            private void Awake ()
            {
                Initialize();
            }

            public void Initialize ()
            {
                botController = GameObject.FindObjectOfType<BotController>();
            }
            public abstract bool IsValid ();
            public abstract IEnumerator Run ();
        #endregion
    }
}
