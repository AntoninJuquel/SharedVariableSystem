using System;
using UnityEngine;

namespace SharedVariableSystem
{
    [Serializable]
    public class SharedVariableField<T>
    {
        [SerializeField] private bool useConstant = true;
        [SerializeField] private T constantValue;
        [SerializeField] private SharedVariable<T> sharedVariable;

        public T Value
        {
            get { 
                if (!sharedVariable || useConstant)
                {
                    return constantValue;
                }

                return sharedVariable.Value;
            }
            set
            {
                if (!sharedVariable || useConstant)
                {
                    constantValue = value;
                }
                else
                {
                    sharedVariable.Value = value;
                }
            }
        }

        public void AddEventListener(Action<T> callback)
        {
            if (!sharedVariable || useConstant)
            {
                return;
            }
            sharedVariable.OnValueChanged += callback;
        }

        public void RemoveEventListener(Action<T> callback)
        {
            if (!sharedVariable || useConstant)
            {
                return;
            }
            sharedVariable.OnValueChanged -= callback;
        }

        public static implicit operator T(SharedVariableField<T> reference)
        {
            return reference.Value;
        }
    }
}