using JetBrains.Annotations;
using SplatTheRat.ScriptableObjects.GameplayObjects;
using SplatTheRat.ScriptableObjects.Settings;
using UnityEngine;

namespace SplatTheRat.Components.Grid
{
    public class FieldGenerator : MonoBehaviour
    {
        [Header("Prefab reference")]
        [SerializeField] private Cell _cellPrefab;
        [Space, Header("Scriptable objects reference")]
        [SerializeField] private ObjectsScale _cellSize;
        [SerializeField] private Field _field;
        [SerializeField] private FieldSetup _fieldSetup;
        [Space, Header("Field settings")] 
        [SerializeField] private float _padding;
        private Camera _mainCamera;

        private void Start()
        {
            _mainCamera = Camera.main;
        }

        [UsedImplicitly]
        public void OnGameStarted()
        {
            _field.ResetField();
            CalculateCubeSize();
            GenerateField();
        }

        private void CalculateCubeSize()
        {
            float aspectRatio = (float) Screen.width / Screen.height;
            float cameraHeight = 2f * _mainCamera.orthographicSize;
            float cameraWidth = cameraHeight * aspectRatio;
        
            _cellSize.Value = (cameraWidth - (_fieldSetup.GridLength - 1) * _padding) / _fieldSetup.GridLength ;
        }

        private void GenerateField()
        {
            //TODO: у меня есть чувство что это можно сократить
        
            float cellWithPaddingSize = _cellSize.Value + _padding;
            float halfCellWithPaddingSize = cellWithPaddingSize * 0.5f;
            float halfGridSize = _fieldSetup.GridLength  * halfCellWithPaddingSize;

            for (int x = 0; x < _fieldSetup.GridLength ; x++)
            {
                for (int y = 0; y < _fieldSetup.GridLength ; y++)
                {
                    var offsetX = x * (_cellSize.Value + _padding) - halfGridSize + halfCellWithPaddingSize;
                    var offsetY = y * (_cellSize.Value + _padding) - halfGridSize + halfCellWithPaddingSize;
                    Vector3 position = new Vector3(offsetX, offsetY, 0);
                    Cell cell = Instantiate(_cellPrefab, position, Quaternion.identity, transform);
                    cell.transform.localScale = new Vector3(_cellSize.Value, _cellSize.Value, 1);
                    _field.AddCellToList(cell);
                }
            }
        }
    }
}