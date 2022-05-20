using System;
using UnityEngine;

namespace ReferenceSharing.Variables
{
    public class Variable<T> : ScriptableObject
    {
        private T _value;
        public event EventHandler<T> OnValueChanged;

        public T Value
        {
            get => _value;
            set
            {
                OnValueChanged?.Invoke(this, value);
                _value = value;
            }
        }
    }
}