using System.Collections.Generic;
using UnityEngine;

namespace SplatTheRat.ScriptableObjects.Utils
{
    [CreateAssetMenu(fileName = "Multiply Int variable", menuName = "SO/Utils/Multiply Int variable")]
    public class MultiplicityInt : ScriptableObject
    {
        private Dictionary<int, int> _properties = new();

        public void RegisterEntity(int id, int amount)
        {
            if (_properties.ContainsKey(id)) return;
            int newVariable = amount;
            _properties.Add(id, newVariable);
        }

        public void UnregisterEntity(int id)
        {
            if (_properties.ContainsKey(id))
                _properties.Remove(id);
        }

        public bool TryGetEntity(int id, out int amount)
        {
            amount = 0;
            
            if (_properties.ContainsKey(id))
            {
                amount = _properties[id];
                return true;
            }

            return false;
        }
    }
}