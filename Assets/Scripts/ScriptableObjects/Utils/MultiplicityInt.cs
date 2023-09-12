using System.Collections.Generic;
using SplatTheRat.Model.Data;
using UnityEngine;

namespace SplatTheRat.ScriptableObjects.Utils
{
    [CreateAssetMenu(fileName = "Multiply Int variable", menuName = "SO/Utils/Multiply Int variable")]
    public class MultiplicityInt : ScriptableObject
    {
        private Dictionary<int, IntProperty> _intVariables = new();

        public void RegisterEntity(int id, int amount)
        {
            if (_intVariables.ContainsKey(id)) return;
            IntProperty newVariable = new IntProperty { Value = amount };
            _intVariables.Add(id, newVariable);
        }

        public void UnregisterEntity(int id)
        {
            if (_intVariables.ContainsKey(id))
                _intVariables.Remove(id);
        }

        public bool TryGetEntity(int id, out IntProperty amount)
        {
            amount = new IntProperty();
            
            if (_intVariables.ContainsKey(id))
            {
                amount = _intVariables[id];
                return true;
            }

            return false;
        }
    }
}