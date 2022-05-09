using UnityEngine;
using System.Collections.Generic;

namespace Game.Controller
{
    using Model;

    public class BoardManager : MonoBehaviour
    {
        #region Variables
            private Dictionary<Position, Platform> board;
            public static BoardManager Instance;
        #endregion

        #region Methods
            private void Awake ()
            {
                if (Instance != null)
                    Destroy(this.gameObject);
                Instance = this;
                
                SetBoard();
            }

            private void SetBoard ()
            {
                Platform[] platforms = GameObject.FindObjectsOfType<Platform>();
                board = new Dictionary<Position, Platform>();

                foreach (Platform platform in platforms)
                {
                    board.Add(platform.Position, platform);
                }
            }

            public bool IsPlatformExists (Position position)
            {
                return board.ContainsKey(position);
            }

            public Vector3 GetPlatformWorldPosition (Position position)
            {
                if (IsPlatformExists(position))
                    return board[position].transform.position;
                
                return -Vector3.one;
            }
        #endregion
    }
}