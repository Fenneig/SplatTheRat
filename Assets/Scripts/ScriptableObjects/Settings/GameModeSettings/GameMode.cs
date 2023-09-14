using SplatTheRat.Model.Data;
using UnityEngine;

namespace SplatTheRat.ScriptableObjects.Settings.GameModeSettings
{
    public abstract class GameMode : ScriptableObject
    {
        [SerializeField] private IntReference _scoreToWin;
        [SerializeField] private GameObject _hudCounterTypePrefab;

        public int ScoreToWin => _scoreToWin.Value;
        public GameObject HUDCounterTypePrefab => _hudCounterTypePrefab;

        public abstract void Setup();
        public abstract bool IsGameLost();
    }
}