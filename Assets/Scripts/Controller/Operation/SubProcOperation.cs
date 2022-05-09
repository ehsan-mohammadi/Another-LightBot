using UnityEngine;
using System.Collections;

namespace Game.Controller.Operation
{
    public class SubProcOperation : BotOperation
    {
        #region Variables
            [SerializeField]
            private int index;
        #endregion

        #region Methods
            public override bool IsValid ()
            {
                return true;
            }

            public override IEnumerator Run()
            {
                for (int i = 0; i < GameManager.Instance.SubProcedures[index].Operations.Count; i++)
                    yield return GameManager.Instance.SubProcedures[index].Operations[i].Run();
            }
        #endregion
    }
}