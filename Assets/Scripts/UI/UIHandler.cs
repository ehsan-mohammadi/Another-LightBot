using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    using Controller;
    using Controller.Operation;

    public class UIHandler : MonoBehaviour
    {
        #region Variables
            [SerializeField]
            private Transform mainProc;

            [SerializeField]
            private Transform[] procs;

            [SerializeField]
            private GameObject buttonRun;

            [SerializeField]
            private GameObject buttonReset;

            [SerializeField]
            private Color colorProcActive;

            [SerializeField]
            private Color colorProcDeactive;

            public static UIHandler Instance;
            public Transform activeProc;
        #endregion

        #region Methods
            private void Awake ()
            {
                if (Instance != null)
                    Destroy(this.gameObject);
                Instance = this;
                activeProc = mainProc;
            }

            internal void AddOperation (UIOperation uiOperation)
            {
                UIOperation instance = Instantiate(uiOperation
                    , Vector3.zero, Quaternion.identity, activeProc);
                instance.IsAdded = true;

                if (activeProc == mainProc)
                    GameManager.Instance.AddOperation(instance.Operation);
                else
                    GameManager.Instance.AddOperationInSubProcedure(instance.Operation, GetIndex(activeProc));
            }

            internal void RemoveOperation (UIOperation uiOperation)
            {
                Destroy(uiOperation.gameObject);

                if (activeProc == mainProc)
                    GameManager.Instance.RemoveOperation(uiOperation.Operation);
                else
                    GameManager.Instance.RemoveOperationFromSubProcedure(uiOperation.Operation, GetIndex(activeProc));
            }

            public void Run ()
            {
                GameManager.Instance.RunCode();
                ShowHideRunButton(false);
            }

            public void Reset ()
            {
                GameManager.Instance.ResetCode();
                ShowHideRunButton(true);
            }

            private void ShowHideRunButton (bool isShow)
            {
                buttonRun.SetActive(isShow);
                buttonReset.SetActive(!isShow);
            }

            public void OnProc (Transform caller)
            {
                DeactiveAllProcs();
                caller.parent.GetComponent<Image>().color = colorProcActive;
                activeProc = caller;
            }

            private void DeactiveAllProcs ()
            {
                mainProc.parent.GetComponent<Image>().color =  colorProcDeactive;

                foreach (Transform proc in procs)
                {
                    proc.parent.GetComponent<Image>().color = colorProcDeactive;
                }
            }

            private int GetIndex (Transform proc)
            {
                for (int i = 0; i < procs.Length; i++)
                {
                    if (proc == procs[i])
                        return i;
                }

                return -1;
            }
        #endregion
    }
}