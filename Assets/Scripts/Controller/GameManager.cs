using UnityEngine;
using System.Collections.Generic;

namespace Game.Controller
{
    using Model;
    using Operation;

    public class GameManager : MonoBehaviour
    {
        #region Variables
            private Procedure mainProcedure = new Procedure();

            public static GameManager Instance;
        #endregion

        #region Methods
            private void Awake ()
            {
                if (Instance != null)
                    Destroy(this.gameObject);
                Instance = this;
            }

            public void AddOperation (BotOperation operation)
            {
                mainProcedure.Add(operation);
            }

            public void RemoveOperation (BotOperation operation)
            {
                mainProcedure.Remove(operation);
            }

            public void ResetCode ()
            {
                StartCoroutine(DoResetCode());
            }

            public void RunCode ()
            {
                StartCoroutine(DoRunCode());
            }

            private System.Collections.IEnumerator DoResetCode ()
            {
                ResetOperation resetOperation = new ResetOperation();
                resetOperation.Initialize();
                yield return resetOperation.Run();
                StopAllCoroutines();
            }

            private System.Collections.IEnumerator DoRunCode ()
            {
                foreach (BotOperation operation in mainProcedure.Operations)
                {
                    yield return operation.Run();
                }

                yield return new WaitForFixedUpdate();
            }
        #endregion
    }
}