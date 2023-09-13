using System;
using UnityEngine;

namespace SplatTheRat.Utils
{
    [Serializable]
    public class Timer
    {
        [SerializeField] private float _value;
        private float _timeUp;

        public float Value
        {
            get => _value;
            set => _value = value;
        }

        public Timer(float value)
        {
            _value = value;
        }

        public void Reset()
        {
            _timeUp = Time.time + _value;
        }

        public void EarlyComplete()
        {
            _timeUp -= _value;
        }

        public bool IsReady => _timeUp <= Time.time;
    }
}