using System;
using TMPro;
using UnityEngine;

namespace ModifierSliderSystem
{
    public class SliderValueTracker : MonoBehaviour, IMultiplierModifier
    {
        [SerializeField] private ModifierSlider _slider;
        [SerializeField] private TextMeshProUGUI _lable;

        public event Action<float> Modified;

        public void Initialize()
        {
            _slider.Modified += OnValueChanged;
        }

        private void OnValueChanged(float value)
        {
            _lable.text = value.ToString();
            Modified?.Invoke(value);
        }
    }
}