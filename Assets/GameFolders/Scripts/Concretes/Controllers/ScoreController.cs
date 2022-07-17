using UdemyProject2.Managers;
using UnityEngine;

namespace UdemyProject2.Controllers
{
    public class ScoreController : MonoBehaviour
    {
        [SerializeField] int score;
        [SerializeField] AudioClip _clip;
        public static System.Action<AudioClip> OnScoreChanged;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            PlayerController player = collision.GetComponent<PlayerController>();
            if (player!=null)
            {
                GameManager.Instance.IncreaseScore(score);
                OnScoreChanged.Invoke(_clip);
                Destroy(this.gameObject);
            }
        }
    }
}