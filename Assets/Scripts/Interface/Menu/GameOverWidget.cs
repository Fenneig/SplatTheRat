using JetBrains.Annotations;
using SplatTheRat.Model.Data;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SplatTheRat.Interface.Menu
{
    public class GameOverWidget : MonoBehaviour
    {
        [SerializeField] private StringVariable _gameOverReason;
        [SerializeField] private TextMeshProUGUI _gameOverReasonText;

        private void Awake()
        {
            gameObject.SetActive(false);
        }

        [UsedImplicitly]
        public void UpdateReason()
        {
            _gameOverReasonText.text = _gameOverReason.Value;
        }

        public void RestartScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}