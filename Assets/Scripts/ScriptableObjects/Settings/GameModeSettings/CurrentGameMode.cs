using UnityEngine;

namespace SplatTheRat.ScriptableObjects.Settings.GameModeSettings
{
    [CreateAssetMenu(fileName = "CurrentGameMode", menuName = "SO/Settings/GameMode/CurrentGameMode")]
    public class CurrentGameMode : ScriptableObject
    {
        [SerializeField] private GameMode _gameMode;

        public GameMode GameMode
        {
            get => _gameMode;
            set => _gameMode = value;
        }
    }
}