using UnityEngine;

public class FieldGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _fieldPartPrefab;
    [SerializeField, Range(2, 7)] private int _gridLength;
    [SerializeField] private float _padding;

    private Camera _mainCamera;
    private float _fieldPartSize;
    
    private void Start()
    {
        _mainCamera = Camera.main;
        CalculateCubeSize();
        GenerateField();
    }

    private void CalculateCubeSize()
    {
        float aspectRatio = (float) Screen.width / Screen.height;
        float cameraHeight = 2f * _mainCamera.orthographicSize;
        float cameraWidth = cameraHeight * aspectRatio;
        
        _fieldPartSize = (cameraWidth - (_gridLength - 1) * _padding) / _gridLength;
    }

    private void GenerateField()
    {
        //TODO: у меня есть чувство что это можно сократить
        
        float cellSize = _fieldPartSize + _padding;
        float halfCellSize = cellSize * 0.5f;
        float halfGridSize = _gridLength * halfCellSize;

        for (int x = 0; x < _gridLength; x++)
        {
            for (int y = 0; y < _gridLength; y++)
            {
                var offsetX = x * (_fieldPartSize + _padding) - halfGridSize + halfCellSize;
                var offsetY = y * (_fieldPartSize + _padding) - halfGridSize + halfCellSize;
                Vector3 position = new Vector3(offsetX, offsetY, 0);
                GameObject fieldPart = Instantiate(_fieldPartPrefab, position, Quaternion.identity, transform);
                fieldPart.transform.localScale = new Vector3(_fieldPartSize, _fieldPartSize, 1);
            }
        }
    }
}