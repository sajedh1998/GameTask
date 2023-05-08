using UnityEngine;

namespace Enemy
{
    public class SpikeRotate : MonoBehaviour
    {
        [SerializeField] private float speed = 2f;

        private void Update()
        {
            transform.Rotate(0, 0, 360 * speed * Time.deltaTime);
        }
    }
}