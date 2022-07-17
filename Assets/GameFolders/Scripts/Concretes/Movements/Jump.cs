using UnityEngine;

namespace UdemyProject2.Movements
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Jump : MonoBehaviour
    {
        [SerializeField] float jumpForce = 350f;
        Rigidbody2D rigidbody2D;
        private void Awake()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
        }
        public void JumpAction()
        {
            rigidbody2D.velocity = Vector2.zero;
            rigidbody2D.AddForce(Vector2.up * jumpForce);
        }
    }
}