using JetBrains.Annotations;
using SplatTheRat.Components.Enemies;
using UnityEngine;

namespace SplatTheRat.Components.Grid
{
    public class Cell : MonoBehaviour
    {
        [SerializeField] private Transform _ratAppearPoint;
        private Rat _rat;
        public bool IsOccupied { get; private set; }

        public void PutRatInCell(Rat rat)
        {
            _rat = rat;
            _rat.transform.position = _ratAppearPoint.position;
            IsOccupied = true;
        }

        [UsedImplicitly]
        public void ClearCell()
        {
            if (_rat == null) IsOccupied = false;
        }
    }
}