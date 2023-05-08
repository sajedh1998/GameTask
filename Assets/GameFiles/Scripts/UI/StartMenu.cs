using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class StartMenu : MonoBehaviour
    {
        public Button startButton;

        private void Awake()
        {
            startButton.onClick.AddListener(PlayGame);
        }

        public void PlayGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}