using System;
using UnityEngine;

namespace ReferenceSharing
{
    public class Variable<T> : ScriptableObject
    {
        [SerializeField] private T value;
        public event Action<T> OnValueChanged;

        public T Value
        {
            get => value;
            set
            {
                this.value = value;
                OnValueChanged?.Invoke(value);
            }
        }
    }
}