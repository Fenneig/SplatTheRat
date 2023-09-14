using JetBrains.Annotations;
using SplatTheRat.Model.Data;
using SplatTheRat.ScriptableObjects.Settings.GameModeSettings;
using UnityEngine;
using UnityEngine.UI;

namespace SplatTheRat.UserInterface.HUD
{
    public class HealthWidget : MonoBehaviour
    {
        [SerializeField] private Image _healthImage;
        [SerializeField] private IntVariable _playerHealth;
        [SerializeField] private CurrentGameMode _gameSettings;

        private HealthMode _healthSettings;

        public void Start()
        {
            _healthSettings = _gameSettings.GameMode as HealthMode;
        }

        [UsedImplicitly]
        public void UpdateHealth()
        {
            _healthImage.fillAmount = (float) _playerHealth.Value / _healthSettings.PlayerMaxHealth.Value;
        }
    }
}