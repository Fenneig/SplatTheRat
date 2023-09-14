﻿using SplatTheRat.Components.Interfaces;
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
        [Header("Event references")]
        [SerializeField] private GameEvent _onEnemyDeadEvent;
        [SerializeField] private GameEvent _onEnemyTimerEnds;
        [SerializeField] private GameEvent _onPlayerHit;
        [Header("Variable references")]
        [SerializeField] private IntVariable _playerScore;
        [SerializeField] private IntVariable _playerHealth;
        [SerializeField] private BoolVariable _isGameOn;
        
        private EnemyDefinition _enemyDefinition;
        private int _health;
        private Timer _timer;
        private int _id;

        public bool IsDead { get; private set; }

        public void InitEnemy(EnemyDefinition enemyDefinition)
        {
            _id = _idMaker.GetId;
            _enemyDefinition = enemyDefinition;
            _enemyDefinition.InitHealth(_id);
            _enemyDefinition.TryGetHealth(_id, out _health);
            Instantiate(_enemyDefinition.Model, transform);
            _timer = new Timer(enemyDefinition.LifeTime);
            _timer.Reset();
            IsDead = false;
        }

        private void Update()
        {
            if (_timer != null && _timer.IsReady && _isGameOn.Value)
            {
                TimerExpire();
            }
        }

        private void TimerExpire()
        {
            IsDead = true;
            _onEnemyTimerEnds.Raise();
            _playerHealth.Value -= _enemyDefinition.Damage;
            _onPlayerHit.Raise();
            Destroy(gameObject);
        }

        public void Damage()
        {
            _health--;
            if (_health <= 0) EnemyDied();
        }

        private void EnemyDied()
        {
            IsDead = true;
            _playerScore.Value += _enemyDefinition.Score;
            _onEnemyDeadEvent.Raise();
            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            _enemyDefinition.DeinitHealth(_id);
        }
    }
}