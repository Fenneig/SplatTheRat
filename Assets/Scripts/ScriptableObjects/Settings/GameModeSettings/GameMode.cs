using UnityEngine;

namespace SplatTheRat.ScriptableObjects.Settings.GameModeSettings
{
    public abstract class GameMode : ScriptableObject
    {
        [SerializeField] private int _scoreToWin;
        [SerializeField] private GameObject _hudCounterTypePrefab;

        public int ScoreToWin => _scoreToWin;
        public GameObject HUDCounterTypePrefab => _hudCounterTypePrefab;

        public abstract void Setup();
        public abstract bool IsGameLost();
    }
}