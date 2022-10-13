using UnityEngine;
using UnityEngine.UI;

namespace ReferenceSharing.ReferencedComponents
{
    public class ReferencedProgressBarDouble : ReferencedComponent<double>
    {
        [SerializeField] private Gradient gradient;
        [SerializeField] private Reference<double> maxDoubleValueRef;
        private Image _fill;

        private void Awake()
        {
            _fill = GetComponent<Image>();
        }

        protected override void OnValueChanged(double value)
        {
            _fill.fillAmount = (float)(valueRef.Value / maxDoubleValueRef.Value);
            _fill.color = gradient.Evaluate(_fill.fillAmount);
        }
    }
}