using UdemyProject2.Managers;
using UnityEngine;

namespace UdemyProject2.Uis
{
    public class MenuPanel : MonoBehaviour
    {
        public void StartButtonClicked()
        {
            GameManager.Instance.LoadScene(1);
        }
        public void ExitBuutonClicked()
        {
            GameManager.Instance.ExitGame();
        }
    }
}