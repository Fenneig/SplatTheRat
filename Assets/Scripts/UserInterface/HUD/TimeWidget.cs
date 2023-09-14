using SplatTheRat.ScriptableObjects.Settings.GameModeSettings;
using UnityEngine;
using UnityEngine.UI;

namespace SplatTheRat.UserInterface.HUD
{
    public class TimeWidget : MonoBehaviour
    {
        [SerializeField] private Image _timeImage;
        [SerializeField] private CurrentGameMode _gameSettings;
        
        private TimeMode _timeSettings;

        public void Start()
        {
            _timeSettings = _gameSettings.GameMode as TimeMode;
        }

        private void Update()
        {
            _timeImage.fillAmount = 1 - _timeSettings.TimeToLose.ReadyProgress;
        }
    }
}