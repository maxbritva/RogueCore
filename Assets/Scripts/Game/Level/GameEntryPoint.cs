using Game.Configurations;
using UnityEngine;

namespace Game.Level
{
    public class GameEntryPoint: MonoBehaviour
    {
        [SerializeField] private PlayerConfiguration _playerConfiguration;
        [SerializeField] private GameObject _endGamePanel;

        public PlayerConfiguration PlayerConfiguration => _playerConfiguration;

        public void EndGame()
        {
            _endGamePanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}