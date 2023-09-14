using SplatTheRat.Utils;
using UnityEngine;

namespace SplatTheRat.ScriptableObjects.Settings.GameModeSettings
{
    [CreateAssetMenu(fileName = "TimeMode", menuName = "SO/Settings/GameMode/Time mode")]
    public class TimeMode : GameMode
    {
        [SerializeField, Tooltip("In seconds")] private Timer _timeToLose;

        public Timer TimeToLose => _timeToLose;
        
        public override void Setup()
        {
            _timeToLose.Reset();
        }

        public override bool IsGameLost()
        {
            return _timeToLose.IsReady;
        }
    }
}