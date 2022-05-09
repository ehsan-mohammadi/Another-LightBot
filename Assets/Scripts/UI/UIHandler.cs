using UnityEngine;

namespace Game.UI
{
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

            internal void AddOperation (OperationClickHandler operation)
            {
                OperationClickHandler instance = Instantiate(operation
                    , Vector3.zero, Quaternion.identity, mainProc);
                instance.IsAdded = true;
            }

            internal void RemoveOperation (OperationClickHandler operation)
            {
                Destroy(operation.gameObject);
            }
        #endregion
    }
}