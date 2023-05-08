using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class GameOverPanel : MonoBehaviour
    {
        public Button restartButton;
        public Button quitButton;

        private void Awake()
        {
            restartButton.onClick.AddListener(RestartLevel);
            quitButton.onClick.AddListener(QuitGame);
        }

        public void RestartLevel()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}