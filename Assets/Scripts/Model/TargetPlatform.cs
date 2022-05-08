using UnityEngine;

namespace Game.Model
{
    public class TargetPlatform : Platform
    {
        #region Variables
            [SerializeField]
            private Material switchOff;

            [SerializeField]
            private Material switchOn;
        #endregion

        #region Methods
            private void OnDrawGizmos ()
            {
                Gizmos.color = Color.cyan;
                for (int i = 0; i < height; i++)
                    Gizmos.DrawWireCube(this.transform.position + (offset * i)
                        , Vector3.one - offset);
            }
        #endregion
    }
}