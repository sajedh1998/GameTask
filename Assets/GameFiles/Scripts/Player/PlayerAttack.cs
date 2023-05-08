using Sound;
using UnityEngine;

namespace Player
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField] private GameObject restartPanel;


        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.CompareTag("Enemy"))
            {
                SoundManager.instance.PlayClip(1);
                EnableReplay();
            }
        }

        public void EnableReplay()
        {
            restartPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}