using JetBrains.Annotations;
using SplatTheRat.ScriptableObjects.Settings.GameModeSettings;
using UnityEngine;

namespace SplatTheRat.UserInterface.HUD
{
    public class HudWidget : MonoBehaviour
    {
        [SerializeField] private CurrentGameMode _currentGameMode;

        [UsedImplicitly]
        public void StartGame()
        {
            Instantiate(_currentGameMode.GameMode.HUDCounterTypePrefab, transform);
        }

        [UsedImplicitly]
        public void GameEnds()
        {
            Destroy(gameObject);
        }
    }
}