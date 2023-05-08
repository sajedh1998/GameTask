using Sound;
using UnityEngine;

namespace Player
{
    [System.Serializable]

    public enum MovementState
    {
        idle, running, jumping, filling
    }

    public class PlayerMovement : MonoBehaviour
    {
        PlayerController actions;
        float direction = 0;
        public float playerSpeed = 500;
        public float jumpForce = 5;
        public LayerMask groundLayer;
        private Rigidbody2D player;
        private SpriteRenderer playerSkin;
        private Animator playerAnimator;
        private string speed = "Speed";
        private CircleCollider2D collider;
        private int jumpsCounr = 0;
        private void Awake()
        {
            player = GetComponent<Rigidbody2D>();
            playerAnimator = GetComponent<Animator>();
            playerSkin = GetComponent<SpriteRenderer>();
            collider = GetComponent<CircleCollider2D>();
            actions = new PlayerController();

            actions.Enable();
            actions.Ground.Move.performed += ctx =>
            {
                direction = ctx.ReadValue<float>();
            };

            actions.Ground.Jump.performed += ctx => Jump();
        }
        private void OnEnable()
        {
            actions.Enable();
        }

        private void OnDisable()
        {
            actions.Disable();
        }

        void FixedUpdate()
        {
            player.velocity = new Vector2(direction * playerSpeed * Time.fixedDeltaTime, player.velocity.y);
            playerAnimator.SetFloat(speed, Mathf.Abs(direction));
            playerSkin.flipX = (direction < 0) ? playerSkin.flipX = true : playerSkin.flipX = false;
            if (player.velocity.y > 0.5f)
            {
                playerAnimator.SetBool("Jump", true);
            }
            else
            {
                playerAnimator.SetBool("Jump", false);
            }
        }

        void Jump()
        {
            if (IsGrounded())
            {
                jumpsCounr = 0;
                SoundManager.instance.PlayClip(0);
                player.velocity = new Vector2(player.velocity.x, jumpForce);
                jumpsCounr++;
            }
            else if (jumpsCounr == 1)
            {
                player.velocity = new Vector2(player.velocity.x, jumpForce);
                jumpsCounr++;
            }
        }

        private bool IsGrounded()
        {
            return Physics2D.BoxCast(collider.bounds.center,
                collider.bounds.size, 0f,
                Vector2.down, 0.1f,
                groundLayer);
        }
    }
}