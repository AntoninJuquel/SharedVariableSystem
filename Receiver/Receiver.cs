using UnityEngine;
using UnityEngine.Events;

namespace ReferenceSharing
{
    public class Receiver<T> : MonoBehaviour
    {
        [SerializeField] private Variable<T> variable;
        [SerializeField] private bool refreshOnEnable = true;
        [SerializeField] private UnityEvent<T> onValueChanged;
        [SerializeField] private UnityEvent<T> onGetValueTriggered;

        private void OnEnable()
        {
            variable.OnValueChanged += RaiseEvent;
            
            if (refreshOnEnable)
            {
                RaiseEvent(variable.Value);
            }
        }

        private void OnDisable()
        {
            variable.OnValueChanged -= RaiseEvent;
        }

        private void RaiseEvent(T value)
        {
            onValueChanged?.Invoke(value);
        }
        
        public void GetValue()
        {
            onGetValueTriggered?.Invoke(variable.Value);
        }
    }
}