using UnityEngine;

namespace Game.UI
{
    using Controller.Operation;

    [RequireComponent(typeof(BotOperation))]
    public class UIOperation : MonoBehaviour
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

            internal BotOperation Operation
            {
                get { return this.GetComponent<BotOperation>(); }
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