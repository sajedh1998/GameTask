using UnityEngine;

namespace Enemy
{
    [System.Serializable]
    public class Ranges
    {
        public Transform x1;
        public bool empty;
    }

    public class EnemySpwaner : MonoBehaviour
    {
        public Ranges[] ranges;
        public GameObject enemy;
        public int amountSpawner;

        private void Start()
        {
            Set();
        }

        public void Set()
        {
            Invoke(nameof(Respawn), 1);
        }

        public void Respawn()
        {
            for (int i = 0; i < amountSpawner; i++)
            {
                int x = Random.Range(0, ranges.Length);
                if (x < ranges.Length && !ranges[x].empty)
                {
                    Instantiate(enemy, ranges[x].x1.position, Quaternion.identity);
                    ranges[x].empty = true;
                }
            }
        }
    }
}