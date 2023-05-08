using UnityEngine;

namespace Enemy
{
    public class FlipEnemy : MonoBehaviour
    {
        [SerializeField] private float speed = 1;
        public GameObject pointA;
        public GameObject pointB;
        Transform currentPoint;
        Rigidbody2D enemyRB;

        private void Start()
        {
            enemyRB = GetComponent<Rigidbody2D>();
            currentPoint = pointB.transform;
        }

        private void Update()
        {
            DistanceCheck();
        }


        private void DistanceCheck()
        {
            Vector2 point = currentPoint.position - transform.position;

            if(currentPoint == pointB.transform)
            {
                enemyRB.velocity = new Vector2(speed, 0f);
            }
            else
            {
                enemyRB.velocity = new Vector2(-speed, 0f);
            }
            if(Vector2.Distance(transform.position, currentPoint.position) < 0.1 && currentPoint == pointB.transform)
            {
                Flip();
                currentPoint = pointA.transform;
            }
            if (Vector2.Distance(transform.position, currentPoint.position) < 0.1 && currentPoint == pointA.transform)
            {
                Flip();
                currentPoint = pointB.transform;
            }
        }
        private void Flip()
        {
            Vector3 localSacle = transform.localScale;
            localSacle.x *= -1;
            transform.localScale = localSacle;
        }
    }
}