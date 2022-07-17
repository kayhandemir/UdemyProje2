using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UdemyProject2.Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        [SerializeField] float _delayTime = 0.3f;
        [SerializeField] int score;
        public System.Action<bool> OnSceneChanged;
        public System.Action<int> OnScoreChanged;
        private void Awake()
        {
            SingletonThisGameObject();
        }
        private void SingletonThisGameObject()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }   
        public void LoadScene(int levelIndex=0)
        {
            StartCoroutine(LoadSceneAsync(levelIndex));
        }
        IEnumerator LoadSceneAsync(int levelIndex)
        {
            yield return new WaitForSeconds(_delayTime);
            int buildIndex = SceneManager.GetActiveScene().buildIndex;
            yield return SceneManager.UnloadSceneAsync(buildIndex);
            SceneManager.LoadSceneAsync(buildIndex + levelIndex, LoadSceneMode.Additive).completed += (AsyncOperation async) => {
                SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(buildIndex + levelIndex));
            };
            OnSceneChanged?.Invoke(false);
        }
        public void ExitGame()
        {
            Application.Quit();
        }
        public void LoadMenuAndUi(float delayLoading)
        {
            StartCoroutine(LoadMenuAndUiAsync(delayLoading));
        }
        IEnumerator LoadMenuAndUiAsync(float delayLoadingTime)
        {
            yield return new WaitForSeconds(delayLoadingTime);
            yield return SceneManager.LoadSceneAsync("Menu");
            yield return SceneManager.LoadSceneAsync("Ui", LoadSceneMode.Additive);
            OnSceneChanged(true);
        }
        public void IncreaseScore(int score)
        {
            this.score += score;
            OnScoreChanged?.Invoke(this.score);
        }
    }
}