using UnityEngine;

namespace UdemyProject2.Movements
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] float _speed = 5.0f;
        public void HorizontalMove(float horizontal)
        {
            transform.Translate(Vector2.right * horizontal * Time.deltaTime * _speed);
        }
    }
}