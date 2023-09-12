using System.Collections.Generic;
using SplatTheRat.Components.Grid;
using SplatTheRat.ScriptableObjects.Definitions;
using SplatTheRat.ScriptableObjects.GameplayObjects;
using UnityEngine;

namespace SplatTheRat.Components.Enemies
{
    public class RatGenerator : MonoBehaviour
    {
        [SerializeField] private Rat _ratPrefab;
        [SerializeField] private Field _field;
        [SerializeField] private List<RatDefinition> _ratDefinitions;

        [ContextMenu("Generate rat")]
        public void GenerateRat()
        {
            Cell cell = _field.GetRandomEmptyCell();
            Rat rat = Instantiate(_ratPrefab);
            int randomRatIndex = Random.Range(0, _ratDefinitions.Count);
            rat.InitRat(_ratDefinitions[randomRatIndex]);
            cell.PutRatInCell(rat);
        }
    }
}