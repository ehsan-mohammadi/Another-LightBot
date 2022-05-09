using UnityEngine;

namespace Game.UI
{
    public class OperationClickHandler : MonoBehaviour
    {
        #region Variables
            private bool isAdded = false;
        #endregion

        #region SetterGetters
            internal bool IsAdded
            {
                get { return isAdded; }
                set { isAdded = value; }
            }
        #endregion

        #region Methods
            public void OnButtonClick ()
            {
                if (!isAdded)
                    UIHandler.Instance.AddOperation(this);
                else
                    UIHandler.Instance.RemoveOperation(this);
            }
        #endregion
    }
}