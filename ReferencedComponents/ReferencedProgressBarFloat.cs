using UnityEngine;
using UnityEngine.UI;

namespace ReferenceSharing.ReferencedComponents
{
    public class ReferencedProgressBarFloat : ReferencedComponent<float>
    {
        [SerializeField] private Gradient gradient;
        [SerializeField] private Reference<float> maxFloatValueRef;
        private Image _fill;

        private void Awake()
        {
            _fill = GetComponent<Image>();
        }

        protected override void OnValueChanged(float value)
        {
            if (maxFloatValueRef.Value == 0) return;
            _fill.fillAmount = valueRef.Value / maxFloatValueRef.Value;
            _fill.color = gradient.Evaluate(_fill.fillAmount);
        }
    }
}