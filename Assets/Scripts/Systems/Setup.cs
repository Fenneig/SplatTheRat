using SplatTheRat.Model.Data;
using SplatTheRat.ScriptableObjects.Events;
using UnityEngine;

namespace SplatTheRat.Systems
{
    public class Setup : MonoBehaviour
    {
        [SerializeField] private IntVariable _playerScore;
        [SerializeField] private IntVariable _playerHealth;
        [SerializeField] private IntReference _playerMaxHealth;
        [SerializeField] private GameEvent _playerHitEvent;
        [SerializeField] private GameEvent _playerScoreEvent;
        
        private void Start()
        {
            _playerScore.Value = 0;
            _playerHealth.Value = _playerMaxHealth.Value;
            _playerHitEvent.Raise();
            _playerScoreEvent.Raise();
        }
    }
}