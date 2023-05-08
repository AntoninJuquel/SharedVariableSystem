using UnityEngine;
using UnityEngine.Events;

namespace ReferenceSharing
{
    public class Receiver<T> : MonoBehaviour
    {
        [SerializeField] private Variable<T> variable;
        [SerializeField] private UnityEvent<T> onValueChanged;

        private void OnEnable()
        {
            variable.OnValueChanged += RaiseEvent;
        }

        private void OnDisable()
        {
            variable.OnValueChanged -= RaiseEvent;
        }

        private void RaiseEvent(T value)
        {
            onValueChanged?.Invoke(value);
        }
    }
}