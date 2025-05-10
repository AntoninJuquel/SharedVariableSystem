using UnityEngine;
using UnityEngine.Events;

namespace SharedVariableSystem
{
    public class SharedVariableListener<T> : MonoBehaviour
    {
        [SerializeField] private SharedVariable<T> variable;
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