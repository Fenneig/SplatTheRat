using JetBrains.Annotations;
using SplatTheRat.Model.Data;
using SplatTheRat.ScriptableObjects.Settings.GameModeSettings;
using UnityEngine;

namespace SplatTheRat.Systems
{
    public class Setup : MonoBehaviour
    {
        [SerializeField] private IntVariable _playerScore;
        [SerializeField] private BoolVariable _isGameOn;
        [SerializeField] private CurrentGameMode _currentGameMode;
        
        [UsedImplicitly]
        public void OnGameStart()
        {
            _playerScore.Value = 0;
            _currentGameMode.GameMode.Setup();
            _isGameOn.Value = true;
        }
    }
}