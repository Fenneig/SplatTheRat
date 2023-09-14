using SplatTheRat.ScriptableObjects.Settings.GameModeSettings;
using UnityEngine;

namespace SplatTheRat.Interface.HUD
{
    public class HudWidget : MonoBehaviour
    {
        [SerializeField] private CurrentGameMode _currentGameMode;

        public void StartGame()
        {
            Instantiate(_currentGameMode.GameMode.HUDCounterTypePrefab, transform);
        }

        public void GameEnds()
        {
            Destroy(gameObject);
        }
    }
}