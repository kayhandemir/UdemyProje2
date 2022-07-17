using System.Linq;
using UdemyProject2.Combats;
using UdemyProject2.Controllers;
using UnityEngine;

namespace UdemyProject2.Managers
{
    public class CheckPointManager : MonoBehaviour
    {
        [SerializeField]
        CheckPointController[] _checkPointControllers;
        Health _health;
        private void Awake()
        {
            _checkPointControllers=GetComponentsInChildren<CheckPointController>();
            _health = FindObjectOfType<PlayerController>().GetComponent<Health>();
        }
        private void Start()
        {
            _health.OnHealthChanged += HandleHealthChanged;
        }

        private void HandleHealthChanged(int currentHealth)
        {
            CheckPointController _control = _checkPointControllers.LastOrDefault<CheckPointController>(x => x.IsPassed);

            if (_control != null)
            {
                _health.transform.position = _control.transform.position;
            }
            else
            {
                _health.transform.position =new Vector3(-14f,0,0);
            }
        }
    }
}