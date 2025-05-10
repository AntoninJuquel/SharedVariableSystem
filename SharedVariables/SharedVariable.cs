using System;
using UnityEngine;

namespace SharedVariableSystem
{
    public class SharedVariable<T> : ScriptableObject
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