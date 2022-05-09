using UnityEngine;

namespace Game.Controller
{
    using Model;
    using Operation;

    public class GameManager : MonoBehaviour
    {
        #region Variables
            [SerializeField]
            private int subProcCount = 0;

            private Procedure mainProcedure = new Procedure();
            private Procedure[] subProcedures;
            public static GameManager Instance;
        #endregion

        #region SetterGetters
            internal Procedure[] SubProcedures
            {
                get { return subProcedures; }
            }
        #endregion

        #region Methods
            private void Awake ()
            {
                if (Instance != null)
                    Destroy(this.gameObject);
                Instance = this;

                Initialize();
            }

            private void Initialize ()
            {
                subProcedures = new Procedure[subProcCount];
                for (int i = 0; i < subProcedures.Length; i++)
                {
                    subProcedures[i] = new Procedure();
                }
            }

            public void AddOperation (BotOperation operation)
            {
                mainProcedure.Add(operation);
            }

            public void RemoveOperation (BotOperation operation)
            {
                mainProcedure.Remove(operation);
            }

            public void AddOperationInSubProcedure (BotOperation operation, int subProcIndex)
            {
                subProcedures[subProcIndex].Add(operation);
            }

            public void RemoveOperationFromSubProcedure (BotOperation operation, int subProcIndex)
            {
                subProcedures[subProcIndex].Remove(operation);
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