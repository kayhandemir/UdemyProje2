using UdemyProject2.Managers;
using UnityEngine;

namespace UdemyProject2.Uis
{
    public class GameOverPanel : MonoBehaviour
    {
        public void YesButtonClicked()
        {
            GameManager.Instance.LoadScene();
            this.gameObject.SetActive(false);
        }
        public void NoButtonClicked()
        {
            GameManager.Instance.LoadMenuAndUi(1f);
        }
    }
}