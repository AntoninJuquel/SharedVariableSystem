using UnityEngine;

namespace ReferenceSharing.Variables
{
    public class Variable<T> : ScriptableObject
    {
        public T value;
    }
}