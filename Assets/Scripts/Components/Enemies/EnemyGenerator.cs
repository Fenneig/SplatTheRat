using System.Collections.Generic;
using SplatTheRat.Components.Grid;
using SplatTheRat.ScriptableObjects.Definitions;
using SplatTheRat.ScriptableObjects.GameplayObjects;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SplatTheRat.Components.Enemies
{
    public class EnemyGenerator : MonoBehaviour
    {
        [SerializeField] private Enemy _enemyPrefab;
        [SerializeField] private Field _field;
        [SerializeField] private List<EnemyDefinition> _enemyDefinitions;

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
            if (Input.GetKeyDown(KeyCode.E)) GenerateRat();
        }
    }
}