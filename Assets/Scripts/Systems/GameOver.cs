using JetBrains.Annotations;
using SplatTheRat.Model.Data;
using SplatTheRat.ScriptableObjects.Events;
using SplatTheRat.ScriptableObjects.Settings.GameModeSettings;
using UnityEngine;

namespace SplatTheRat.Systems
{
    public class GameOver : MonoBehaviour
    {
        [Header("Scriptable object references")] 
        [Header("Game settings")]
        [SerializeField] private CurrentGameMode _currentGameMode;
        [SerializeField] private BoolVariable _isGameOn;
        [Space,Header("Messages references")]
        [SerializeField] private StringVariable _winMessage;
        [SerializeField] private StringVariable _loseMessage;
        [SerializeField] private StringVariable _gameOverReason;
        [Space, Header("Events")] 
        [SerializeField] private GameEvent _gameEnd;
        [Space, Header("Player stats")] 
        [SerializeField] private IntVariable _playerScore;

        private void Update()
        {
            if (_currentGameMode.GameMode is not TimeMode || !_isGameOn.Value) return;

            if (_currentGameMode.GameMode.IsGameLost()) OnGameEnd();
        }

        [UsedImplicitly]
        public void OnEnemyDied()
        {
            if (_playerScore.Value >= _currentGameMode.GameMode.ScoreToWin) OnGameEnd();
        }

        [UsedImplicitly]
        public void OnPlayerHit()
        {
            if (_currentGameMode.GameMode is not HealthMode) return;
            
            if (_currentGameMode.GameMode.IsGameLost()) OnGameEnd();
        }

        private void OnGameEnd()
        {
            _gameOverReason.Value = _currentGameMode.GameMode.IsGameLost() ? _loseMessage.Value : _winMessage.Value;
            _isGameOn.Value = false;
            _gameEnd.Raise();
        }
    }
}