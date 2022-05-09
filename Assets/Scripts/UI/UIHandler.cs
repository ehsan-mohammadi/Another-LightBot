using UnityEngine;

namespace Game.UI
{
    using Controller;

    public class UIHandler : MonoBehaviour
    {
        #region Variables
            [SerializeField]
            private Transform mainProc;

            public static UIHandler Instance;
        #endregion

        #region Methods
            private void Awake ()
            {
                if (Instance != null)
                    Destroy(this.gameObject);
                Instance = this;
            }

            internal void AddOperation (UIOperation uiOperation)
            {
                UIOperation instance = Instantiate(uiOperation
                    , Vector3.zero, Quaternion.identity, mainProc);
                instance.IsAdded = true;

                GameManager.Instance.AddOperation(instance.Operation);
            }

            internal void RemoveOperation (UIOperation uiOperation)
            {
                Destroy(uiOperation.gameObject);
                GameManager.Instance.RemoveOperation(uiOperation.Operation);
            }
        #endregion
    }
}