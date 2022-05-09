using UnityEngine;

namespace Game.UI
{
    using Controller;

    public class MainMenuClickHandler : MonoBehaviour
    {
        #region Methods
            public void OnLevelButton (int index)
            {
                GameManager.LoadLevel(index);
            }
        #endregion
    }
}
