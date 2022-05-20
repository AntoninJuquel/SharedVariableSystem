using UnityEngine;

namespace ReferenceSharing.ReferencedComponents
{
    public abstract class ReferencedComponent<T> : MonoBehaviour
    {
        [SerializeField] protected Reference<T> valueRef;

        private void OnEnable()
        {
            valueRef.AddEventListener(OnValueChanged);
        }

        private void OnDisable()
        {
            valueRef.RemoveEventListener(OnValueChanged);
        }

        protected abstract void OnValueChanged(object sender, T value);
    }
}