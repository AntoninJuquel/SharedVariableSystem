using UnityEngine;
using UnityEngine.UI;

namespace ReferenceSharing.ReferencedComponents
{
    public class ReferencedProgressBarInt : ReferencedComponent<int>
    {
        [SerializeField] private Gradient gradient;
        [SerializeField] private Reference<int> maxIntValueRef;
        private Image _fill;

        private void Awake()
        {
            _fill = GetComponent<Image>();
        }

        protected override void OnValueChanged(int value)
        {
            if (maxIntValueRef.Value == 0) return;
            _fill.fillAmount = (float) valueRef.Value / maxIntValueRef.Value;
            _fill.color = gradient.Evaluate(_fill.fillAmount);
        }
    }
}