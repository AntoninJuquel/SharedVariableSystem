using UnityEngine;

namespace ReferenceSharing.ReferencedComponents
{
    public abstract class ReferencedComponent<T> : MonoBehaviour
    {
        [SerializeField] protected Reference<T> valueRef;

        private void OnEnable()
        {
            valueRef.AddEventListener(OnValueChanged);
            OnValueChanged(this, valueRef.Value);
        }

        private void OnDisable()
        {
            valueRef.RemoveEventListener(OnValueChanged);
        }

        protected abstract void OnValueChanged(object sender, T value);
    }
}