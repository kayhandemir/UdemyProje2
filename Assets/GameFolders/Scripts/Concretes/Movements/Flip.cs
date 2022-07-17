using UnityEngine;

namespace UdemyProject2.Movements
{
    public class Flip : MonoBehaviour
    {
        public void Flipcharacter(float horizontal)
        {
            if (horizontal!=0)
            {
                float mathfValue = Mathf.Sign(horizontal);
                if (transform.localScale.x == horizontal) return;
                transform.localScale = new Vector3(mathfValue, 1f);
            }
        }
    }
}