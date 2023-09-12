using SplatTheRat.Components.Interfaces;
using SplatTheRat.Model.Data;
using SplatTheRat.ScriptableObjects.Definitions;
using SplatTheRat.ScriptableObjects.Events;
using SplatTheRat.ScriptableObjects.Utils;
using UnityEngine;

namespace SplatTheRat.Components.Enemies
{
    public class Rat : MonoBehaviour, IDamageable
    {
        [Header("Scriptable object references")]
        [SerializeField] private IdMaker _idMaker;
        [SerializeField] private GameEvent _onRatDeadEvent;
        
        private RatDefinition _ratDefinition;
        private IntProperty _health;
        private int _id;

        public void InitRat(RatDefinition ratDefinition)
        {
            _id = _idMaker.GetId;
            _ratDefinition = ratDefinition;
            _ratDefinition.InitHealth(_id);
            _ratDefinition.TryGetHealth(_id, out _health);
        }

        [ContextMenu("damage rat")]
        public void Damage()
        {
            _health.Value--;
            if (_health.Value <= 0) _onRatDeadEvent.Raise();
        }

        public void Death()
        {
            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            _ratDefinition.DeinitHealth(_id);
        }
    }
}