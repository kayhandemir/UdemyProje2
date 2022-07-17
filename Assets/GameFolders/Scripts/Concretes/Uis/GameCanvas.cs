using UdemyProject2.Managers;
using UnityEngine;

namespace UdemyProject2.Uis
{
    public class GameCanvas : MonoBehaviour
    {
        [SerializeField] GameObject gamePlayObject;
        [SerializeField] GameOverPanel gameOverPanel;
        private void OnEnable()
        {
            GameManager.Instance.OnSceneChanged += HandleSceneChanged;
        }
        private void OnDisable()
        {
            GameManager.Instance.OnSceneChanged -= HandleSceneChanged;
        }
        private void HandleSceneChanged(bool isActive)
        {
            if (!isActive == gamePlayObject.gameObject.activeSelf) return;
            gamePlayObject.gameObject.SetActive(!isActive);
        }
        public void ShowGameOverPanel()
        {
            gameOverPanel.gameObject.SetActive(true);
        }
    }
}