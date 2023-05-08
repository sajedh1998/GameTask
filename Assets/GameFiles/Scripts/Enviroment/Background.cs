using UnityEngine;

namespace Background
{
    public class Background : MonoBehaviour
    {
        public Transform mainCamera;
        public Transform middleBg;
        public Transform sideBg;
        float backgroundLength = 38f;

        private void Update()
        {
            if (mainCamera.position.x > middleBg.position.x)
            {
                sideBg.position = middleBg.position + Vector3.right * backgroundLength;
            }
            else if (mainCamera.position.x < middleBg.position.x)
            {
                sideBg.position = middleBg.position + Vector3.left * backgroundLength;
            }
            else if (mainCamera.position.x > sideBg.position.x || mainCamera.position.x < sideBg.position.x)
            {
                Transform z = middleBg;
                middleBg = sideBg;
                sideBg = z;
            }
        }
    }
}