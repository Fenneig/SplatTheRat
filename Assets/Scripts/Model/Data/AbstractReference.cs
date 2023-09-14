using System;
using UnityEngine;

namespace SplatTheRat.Model.Data
{
    [Serializable]
    public class AbstractReference<T>
    {
        [SerializeField] private bool _useConstant;
        [SerializeField] private T _constantValue;
        [SerializeField] private AbstractVariable<T> _variable;

        public T Value => _useConstant ? _constantValue : _variable.Value;
    }
}