using System;
using UnityEngine;

namespace SplatTheRat.Model.Data
{
    [Serializable]
    public class ObservableProperty<T>
    {
        [SerializeField] protected T _value;

        public delegate void OnPropertyChanged(T newValue);

        public event OnPropertyChanged OnChanged;

        public virtual T Value
        {
            get => _value;
            set
            {
                bool isSame = _value?.Equals(value) ?? false;
                if (isSame) return;
                _value = value;
                OnChanged?.Invoke(_value);
            }
        }
    }
}