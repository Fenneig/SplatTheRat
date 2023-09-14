using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SplatTheRat.ScriptableObjects.Events
{
    public class GameEventListeners : MonoBehaviour
    {
        [SerializeField] private List<GameEventListener> _gameEventListeners;

        private void OnEnable()
        {
            foreach (var gameEventListener in _gameEventListeners)
                gameEventListener.RegisterListener();
        }

        private void OnDisable()
        {
            foreach (var gameEventListener in _gameEventListeners)
                gameEventListener.UnregisterListener();
        }
    }
    
    [Serializable]
    public class GameEventListener
    {
        [Header("Scriptable object reference")]
        [SerializeField, Tooltip("Event ot register with")] private GameEvent _event;
        [Space, Header("Game object event response")]
        [SerializeField, Tooltip("Response to invoke when Event is raised")] private UnityEvent _response;

        public void RegisterListener() => _event.RegisterListener(this);

        public void UnregisterListener() => _event.UnregisterListener(this);

        public void OnEventRaised()
        {
            _response?.Invoke();
        }
    }
}