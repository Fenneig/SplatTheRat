using SplatTheRat.Components.Interfaces;
using SplatTheRat.Model.Data;
using SplatTheRat.ScriptableObjects.Definitions;
using SplatTheRat.ScriptableObjects.Events;
using SplatTheRat.ScriptableObjects.Utils;
using SplatTheRat.Utils;
using UnityEngine;

namespace SplatTheRat.Components.Enemies
{
    public class Enemy : MonoBehaviour, IDamageable
    {
        [Header("Scriptable object references")]
        [SerializeField] private IdMaker _idMaker;
        [SerializeField] private GameEvent _onEnemyDeadEvent;
        [SerializeField] private GameEvent _onEnemyTimerEnds;
        
        private EnemyDefinition _enemyDefinition;
        private IntProperty _health;
        private Timer _timer;
        private int _id;

        public void InitEnemy(EnemyDefinition enemyDefinition)
        {
            _id = _idMaker.GetId;
            _enemyDefinition = enemyDefinition;
            _enemyDefinition.InitHealth(_id);
            _enemyDefinition.TryGetHealth(_id, out _health);
            Instantiate(_enemyDefinition.Model, transform);
            _timer = new Timer(enemyDefinition.LifeTime.Value);
            _timer.Reset();
        }

        private void Update()
        {
            if (_timer != null && _timer.IsReady)
            {
                _onEnemyTimerEnds.Raise();
                Death();
            }
        }

        public void Damage()
        {
            _health.Value--;
            if (_health.Value > 0) return;
            
            _onEnemyDeadEvent.Raise();
            Death();
        }

        private void Death()
        {
            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            _enemyDefinition.DeinitHealth(_id);
        }
    }
}