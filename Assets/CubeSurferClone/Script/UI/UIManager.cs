using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

namespace CubeSurferClone.UI
{
    public class UIManager : MonoBehaviour
    {
        const byte GameSuccessPanel = 0, GameFailedPanel = 1;
        [SerializeField] private GameObject[] gamePanels = new GameObject[2];
        public static UIManager Instance { get; private set; }

        [SerializeField] private GameObject _scorePanel; 

        private void Awake()
        {
            Instance = this;
        }

        public void ActiveGameSuccess()
        {
            gamePanels[GameSuccessPanel].SetActive(true);
        }
        public void ActiveGameFailed()
        {
            gamePanels[GameFailedPanel].SetActive(true);
        }

        public void GameRestart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void DiamondScale()
        {
            _scorePanel.transform.DOScale(new Vector3(.8f, .8f, .8f) * 1.15f, 0.15f).OnComplete(() =>
                _scorePanel.transform.DOScale(new Vector3(.8f, .8f, .8f), 0.15f));
        }
    }
}