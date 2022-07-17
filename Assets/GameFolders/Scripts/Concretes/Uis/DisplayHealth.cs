using TMPro;
using UnityEngine;

namespace UdemyProject2.Uis
{
    public class DisplayHealth : MonoBehaviour
    {
        TextMeshProUGUI _healthText;
        private void Awake()
        {
            _healthText = GetComponent<TextMeshProUGUI>();
        }
        public void IncreaseHealth(int currentHealth)
        {
            _healthText.text = currentHealth.ToString();
        }
    }
}