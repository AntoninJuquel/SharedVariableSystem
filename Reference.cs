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
            get { return useConstant ? constantValue : Variable.value;}
            set
            {
                if (useConstant)
                    constantValue = value;
                else
                    Variable.value = value;
            }
        }
        
        public static implicit operator T(Reference<T> reference)
        {
            return reference.Value;
        }
    }
}