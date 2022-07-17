using UnityEngine;

namespace UdemyProject2.Movements
{
    public class OnGround : MonoBehaviour
    {
        [SerializeField] Transform[] translates;
        [SerializeField] bool isGround = false;
        [SerializeField] float maxDistance = 0.15f;
        [SerializeField] LayerMask layerMask;
        public bool IsOnGround => isGround;
        private void Update()
        {
            foreach (var footTransform in translates)
            {
                CheckFootOnGround(footTransform);
                if (isGround) break;
            }
        }

        private void CheckFootOnGround(Transform footTransform)
        {
            RaycastHit2D hit = Physics2D.Raycast(footTransform.position, footTransform.forward,maxDistance,layerMask);
            Debug.DrawRay(footTransform.position, footTransform.forward * maxDistance, Color.red);
            if (hit.collider!=null)
            {
                isGround = true;
            }
            else
            {
                isGround = false;
            }
        }
    }
}