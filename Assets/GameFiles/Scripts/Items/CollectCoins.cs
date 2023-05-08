using Sound;
using TMPro;
using UnityEngine;

namespace Item
{
    public class CollectCoins : MonoBehaviour
    {
        public TextMeshProUGUI coinsCounter;
        int coinsNumber;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Coin"))
            {
                coinsNumber++;
                coinsCounter.text = coinsNumber.ToString();
                SoundManager.instance.PlayClip(2);
                Destroy(collision.gameObject);
            }
        }
    }
}