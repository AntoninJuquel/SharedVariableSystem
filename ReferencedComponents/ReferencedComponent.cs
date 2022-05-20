using UnityEngine;

namespace ReferenceSharing.ReferencedComponents
{
    public abstract class ReferencedComponent<T> : MonoBehaviour
    {
        [SerializeField] protected Reference<T> valueRef;

        private void OnEnable()
        {
            valueRef.SubscribeOnValueChanged(OnValueChanged);
        }

        private void OnDisable()
        {
            valueRef.UnsubscribeOnValueChanged(OnValueChanged);
        }

        protected abstract void OnValueChanged(object sender, T value);
    }
}