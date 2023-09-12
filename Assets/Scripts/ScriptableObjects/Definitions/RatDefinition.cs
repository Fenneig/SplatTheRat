using SplatTheRat.Model.Data;
using SplatTheRat.ScriptableObjects.Utils;
using UnityEngine;

namespace SplatTheRat.ScriptableObjects.Definitions
{
    [CreateAssetMenu(fileName = "Rat", menuName = "SO/Definitions/Rat")]
    public class RatDefinition : ScriptableObject
    {
        [SerializeField] private IntReference _maxHealth;
        [SerializeField] private MultiplicityInt _health;

        public void InitHealth(int id) => _health.RegisterEntity(id, _maxHealth.Value);

        public bool TryGetHealth(int id, out IntProperty value) => _health.TryGetEntity(id, out value);

        public void DeinitHealth(int id) => _health.UnregisterEntity(id);
    }
}