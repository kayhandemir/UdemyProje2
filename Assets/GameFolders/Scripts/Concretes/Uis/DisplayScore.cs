using TMPro;
using UdemyProject2.Managers;
using UnityEngine;

namespace UdemyProject2.Uis
{
    public class DisplayScore : MonoBehaviour
    {
        TextMeshProUGUI scoreText;
        private void Awake()
        {
            scoreText= GetComponent<TextMeshProUGUI>();
        }
        private void OnEnable()
        {
            GameManager.Instance.OnScoreChanged += HandleScoreChanged;
        }
        private void OnDisable()
        {
            GameManager.Instance.OnScoreChanged -= HandleScoreChanged;
        }
        void HandleScoreChanged(int score)
        {
            scoreText.text = score.ToString();
        }
    }
}