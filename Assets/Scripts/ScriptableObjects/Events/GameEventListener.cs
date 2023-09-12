using UnityEngine;
using UnityEngine.Events;

namespace SplatTheRat.ScriptableObjects.Events
{
    public class GameEventListener : MonoBehaviour
    {
        [Header("Scriptable object reference")]
        [SerializeField, Tooltip("Event ot register with")] private GameEvent _event;
        [Space, Header("Game object event response")]
        [SerializeField, Tooltip("Response to invoke when Event is raised")] private UnityEvent _response;

        private void OnEnable()
        {
            _event.RegisterListener(this);
        }

        private void OnDisable()
        {
            _event.UnregisterListener(this);
        }

        public void OnEventRaised()
        {
            _response?.Invoke();
        }
    }
}