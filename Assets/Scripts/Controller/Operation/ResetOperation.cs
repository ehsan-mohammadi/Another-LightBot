﻿using System.Collections;

namespace Game.Controller.Operation
{
    public class ResetOperation : BotOperation
    {
        #region Methods
            public override bool IsValid ()
            {
                return true;
            }

            public override IEnumerator Run ()
            {
                botController.Reset();
                yield return null;
            }
        #endregion
    }
}