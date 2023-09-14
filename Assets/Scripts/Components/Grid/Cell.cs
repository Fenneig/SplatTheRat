using SplatTheRat.Components.Enemies;
using SplatTheRat.ScriptableObjects.Settings;
using UnityEngine;

namespace SplatTheRat.Components.Grid
{
    public class Cell : MonoBehaviour
    {
        [SerializeField] private Transform _enemyAppearPoint;
        [SerializeField] private ObjectsScale _objectsScale;
        private Enemy _enemy;
        
        public bool IsOccupied { get; private set; }

        public void PutRatInCell(Enemy enemy)
        {
            _enemy = enemy;
            _enemy.transform.position = _enemyAppearPoint.position;
            _enemy.transform.localScale = Vector3.one * _objectsScale.Value;
            IsOccupied = true;
        }
        
        public void ClearCell()
        {
            if (_enemy == null || _enemy.IsDead) IsOccupied = false;
        }
    }
}