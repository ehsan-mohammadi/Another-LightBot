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

            public bool PlatformIsExists (Position position)
            {
                return board.ContainsKey(position);
            }

            public Vector3 GetPlatformWorldPosition (Position position)
            {
                if (PlatformIsExists(position))
                    return board[position].transform.position;
                
                return -Vector3.one;
            }

            public Platform GetPlatform (Position position)
            {
                if (PlatformIsExists(position))
                    return board[position];
                
                return null;
            }

            public TargetPlatform GetTargetPlatform (Position position)
            {
                if (PlatformIsExists(position))
                {
                    Platform platform = board[position];
                    if (platform.GetComponent<TargetPlatform>())
                        return platform.GetComponent<TargetPlatform>();
                }

                return null;
            }

            public void ResetAllTargetPlatforms ()
            {
                foreach (Platform platform in board.Values)
                {
                    if (platform.GetComponent<TargetPlatform>())
                        platform.GetComponent<TargetPlatform>().Reset();
                }
            }
        #endregion
    }
}