using UnityEngine;

namespace Game.Model
{
    public class Platform : MonoBehaviour
    {
        #region Variables
            [SerializeField]
            protected int height = 1;

            [SerializeField]
            private GameObject block;
            
            protected static readonly Vector3 offset = new Vector3(0, 0.5f, 0);
        #endregion

        #region SetterGetters
            public int Height
            {
                get { return height; }
                set { height = value; }
            }
        #endregion

        #region Methods
            public void Awake ()
            {
                GenerateBlockStack();
            }

            private void GenerateBlockStack ()
            {
                for (int i = 0; i < height; i++)
                {
                    Instantiate(block
                        , this.transform.position + (offset * i)
                        , Quaternion.identity
                        , this.transform);
                }
            }

            private void OnDrawGizmos ()
            {
                for (int i = 0; i < height; i++)
                    Gizmos.DrawWireCube(this.transform.position + (offset * i)
                        , Vector3.one - offset);
            }
        #endregion
    }
}