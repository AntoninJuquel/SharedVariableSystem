using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ReferenceSharing.ReferencedComponents
{
    public class ReferencedToggle : ReferencedComponent<bool>
    {
        private Toggle _toggle;

        private void Awake()
        {
            _toggle = GetComponent<Toggle>();
        }

        protected override void OnValueChanged(bool value)
        {
            _toggle.isOn = value;
        }
    }
}