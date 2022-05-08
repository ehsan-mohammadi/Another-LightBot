using System;

namespace Game.Model
{
    [Serializable]
    public class Position
    {
        #region Variables
            public int x;
            public int y;
        #endregion

        #region Methods
            public Position ()
            {
                this.x = this.y = 0;
            }

            public Position (int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        #endregion
    }
}