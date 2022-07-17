using UdemyProject2.Controllers;
using UnityEngine;

namespace UdemyProject2.Observers
{
    public class SoundObserver : MonoBehaviour
    {
        AudioSource _audioSource;
        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }
        private void OnEnable()
        {
            PlayerController.OnPlayerDead += PlaySoundShot;
            EnemyController.OnEnemyDead += PlaySoundShot;
            ScoreController.OnScoreChanged += PlaySoundShot;
        }
        private void OnDisable()
        {
            PlayerController.OnPlayerDead -= PlaySoundShot;
            EnemyController.OnEnemyDead -= PlaySoundShot;
            ScoreController.OnScoreChanged -= PlaySoundShot;
        }
        public void PlaySoundShot(AudioClip clip)
        {
            _audioSource.PlayOneShot(clip);
        }
    }
}