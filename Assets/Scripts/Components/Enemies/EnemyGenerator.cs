using System.Collections.Generic;
using SplatTheRat.Components.Grid;
using SplatTheRat.Model.Data;
using SplatTheRat.ScriptableObjects.Definitions;
using SplatTheRat.ScriptableObjects.GameplayObjects;
using SplatTheRat.Utils;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SplatTheRat.Components.Enemies
{
    public class EnemyGenerator : MonoBehaviour
    {
        [SerializeField] private Enemy _enemyPrefab;
        [SerializeField] private Field _field;
        [SerializeField] private List<EnemyDefinition> _enemyDefinitions;
        [SerializeField] private FloatReference _timerReference;
        [SerializeField] private BoolVariable _isGameOn;

        private Timer _timer = new();

        private void Awake()
        {
            _timer.Value = _timerReference.Value;
        }

        public void OnGameStarted()
        {
            _timer.Reset();
        }
        
        private void GenerateRat()
        {
            if (!_field.TryGetRandomEmptyCell(out Cell cell)) return;
            Enemy enemy = Instantiate(_enemyPrefab);
            int randomEnemyIndex = Random.Range(0, _enemyDefinitions.Count);
            enemy.InitEnemy(_enemyDefinitions[randomEnemyIndex]);
            cell.PutRatInCell(enemy);
        }

        private void Update()
        {
            if (!_isGameOn.Value) return;
            if (!_timer.IsReady) return;
            
            GenerateRat();
            _timer.Reset();
        }
    }
}