using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game.UI
{
    public class EndGamePanel : MonoBehaviour
    {
        [SerializeField] private Button _restartButton;
        
        private void OnEnable() => _restartButton.onClick.AddListener(RestartGame);

        private void OnDisable() => _restartButton.onClick.RemoveListener(RestartGame);

        private void RestartGame()
        {
            SceneManager.LoadSceneAsync(0);
            Time.timeScale = 1f;
        }
    }
}