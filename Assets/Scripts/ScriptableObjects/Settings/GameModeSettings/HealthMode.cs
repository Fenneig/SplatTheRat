using SplatTheRat.Model.Data;
using UnityEngine;

namespace SplatTheRat.ScriptableObjects.Settings.GameModeSettings
{
    [CreateAssetMenu(fileName = "HealthMode", menuName = "SO/Settings/GameMode/Health mode")]
    public class HealthMode : GameMode
    {
        [SerializeField] private IntVariable _playerHealth;
        [SerializeField] private IntReference _playerMaxHealth;
        
        public IntReference PlayerMaxHealth => _playerMaxHealth;
        
        public override void Setup()
        {
            _playerHealth.Value = _playerMaxHealth.Value;
        }

        public override bool IsGameLost()
        {
            return _playerHealth.Value <= 0;
        }
    }
}