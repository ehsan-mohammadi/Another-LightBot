using UnityEngine;
using System.Collections.Generic;

namespace Game.Controller
{
    using Operation;

    public class GameManager : MonoBehaviour
    {
        #region Variables
            private List<BotOperation> botOperations = new List<BotOperation>();

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
                botOperations.Add(operation);
            }

            public void RemoveOperation (BotOperation operation)
            {
                botOperations.Remove(operation);
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
                foreach (BotOperation operation in botOperations)
                {
                    yield return operation.Run();
                }

                yield return new WaitForFixedUpdate();
            }
        #endregion
    }
}