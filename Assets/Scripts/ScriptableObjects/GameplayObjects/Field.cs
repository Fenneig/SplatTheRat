using System.Collections.Generic;
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

        public Cell GetRandomEmptyCell()
        {
            Cell cell = null;
            bool isCellPicked = false;
            while (!isCellPicked)
            {
                cell = _cellsList[Random.Range(0, _cellsList.Count)];
                if (!cell.IsOccupied) isCellPicked = true;
            }

            if (cell == null)
            {
                Debug.Log("Every cell is captured");
            }

            return cell;
        }
    }
}