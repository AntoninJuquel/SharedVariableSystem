using System;
using ReferenceSharing.Variables;
using UnityEngine;

namespace ReferenceSharing
{
    [Serializable]
    public class Reference<T>
    {
        [SerializeField] private bool useConstant = true;
        [SerializeField] private T constantValue;
        [SerializeField] private Variable<T> Variable;

        public T Value
        {
            get { return useConstant ? constantValue : Variable.Value;}
            set
            {
                if (useConstant)
                    constantValue = value;
                else
                    Variable.Value = value;
            }
        }

        public void AddEventListener(System.EventHandler<T> callback)
        {
            Variable.OnValueChanged += callback;
        }
        
        public void RemoveEventListener(System.EventHandler<T> callback)
        {
            Variable.OnValueChanged -= callback;
        }
        
        public static implicit operator T(Reference<T> reference)
        {
            return reference.Value;
        }
    }
}