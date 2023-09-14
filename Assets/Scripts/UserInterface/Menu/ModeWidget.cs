using SplatTheRat.ScriptableObjects.Settings.GameModeSettings;
using UnityEngine;

namespace SplatTheRat.UserInterface.Menu
{
    public class ModeWidget : MonoBehaviour
    {
        [SerializeField] private CurrentGameMode _currentGameMode;
        [SerializeField] private HealthMode _healthMode;
        [SerializeField] private TimeMode _timeMode;

        public void SetGameModeAsHealthMode()
        {
            _currentGameMode.GameMode = _healthMode;
        }
        
        public void SetGameModeAsTimeMode()
        {
            _currentGameMode.GameMode = _timeMode;
        }
    }
}