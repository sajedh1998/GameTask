using Sound;
using UnityEngine;

namespace Player
{
    public class FinishLevel : MonoBehaviour
    {
        public bool levelCompleted;
        public GameObject winnerPanel;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.name == "Player" && !levelCompleted)
            {
                SoundManager.instance.PlayClip(3);
                levelCompleted = true;
                Time.timeScale = 0;
                winnerPanel.SetActive(true);
            }
        }

    }
}