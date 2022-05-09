using System.Collections.Generic;

namespace Game.Model
{
    using Controller.Operation;

    public class Procedure
    {
        #region Variables
            private List<BotOperation> operations;
        #endregion

        #region SetterGetters
            public List<BotOperation> Operations
            {
                get { return operations; }
            }
        #endregion

        #region Methods
            public Procedure ()
            {
                operations = new List<BotOperation>();
            }

            public void Add (BotOperation operation)
            {
                operations.Add(operation);
            }

            public void Remove (BotOperation operation)
            {
                operations.Remove(operation);
            }
        #endregion
    }
}