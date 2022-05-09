using UnityEngine;

namespace Game.Model
{
    using Controller;

    public class TargetPlatform : Platform
    {
        #region Variables
            [SerializeField]
            private Material switchOff;

            [SerializeField]
            private Material switchOn;

            private bool isSwitchOn = false;
        #endregion

        #region Methods
            private void OnDrawGizmos ()
            {
                Gizmos.color = Color.cyan;
                for (int i = 0; i < height; i++)
                    Gizmos.DrawWireCube(this.transform.position + (offset * i)
                        , Vector3.one - offset);
            }

            public void Switch ()
            {
                isSwitchOn = !isSwitchOn;
                Material[] materials = lastBlock.GetComponent<MeshRenderer>().materials;
                materials[2] = isSwitchOn ? switchOn : switchOff;
                lastBlock.GetComponent<MeshRenderer>().materials = materials;

                if (BoardManager.Instance.IsAllTargetsSwitchOn())
                    GameManager.Instance.Finish();
            }

            public void Reset ()
            {
                isSwitchOn = false;
                Material[] materials = lastBlock.GetComponent<MeshRenderer>().materials;
                materials[2] = isSwitchOn ? switchOn : switchOff;
                lastBlock.GetComponent<MeshRenderer>().materials = materials;
            }

            public bool GetSwitchStatus ()
            {
                return isSwitchOn;
            }
        #endregion
    }
}