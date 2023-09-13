using System.Collections.Generic;
using System.Linq;
using SplatTheRat.Components;
using SplatTheRat.Components.Grid;
using UnityEngine;

namespace SplatTheRat.ScriptableObjects.GameplayObjects
{
    [CreateAssetMenu(fileName = "Field", menuName = "SO/GameplayObjects/Field")]
    public class Field : ScriptableObject
    {
        private List<Cell> _cellsList = new();  
        
        public void ResetField()
        {
            _cellsList = new List<Cell>();
        }

        public void AddCellToList(Cell cell)
        {
            _cellsList.Add(cell);
        }

        public bool TryGetRandomEmptyCell(out Cell cell)
        {
            cell = null;
            
            if (!CheckListForEmptyCell()) return false;

            PickRandomCell(ref cell);

            return cell != null;
        }

        private void PickRandomCell(ref Cell cell)
        {
            bool isCellPicked = false;
            
            while (!isCellPicked)
            {
                cell = _cellsList[Random.Range(0, _cellsList.Count)];
                if (!cell.IsOccupied) isCellPicked = true;
            }
        }

        private bool CheckListForEmptyCell() => _cellsList.Any(cell => !cell.IsOccupied);
    }
}