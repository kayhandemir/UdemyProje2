using UdemyProject2.Movements;
using UnityEngine;

namespace UdemyProject2.Controllers
{
    public class LeadderController : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            ExitEnterOnTrigger2D(collision,0f,true);
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            ExitEnterOnTrigger2D(collision,1f,false);
        }
        void ExitEnterOnTrigger2D(Collider2D collision,float gravityForce,bool isClimbing)
        {
            Climbing playerClimbing = collision.GetComponent<Climbing>();
            if (playerClimbing != null)
            {
                playerClimbing.Rigidbody.gravityScale = gravityForce;
                playerClimbing.IsClimbing = isClimbing;
            }
        }
    }
}