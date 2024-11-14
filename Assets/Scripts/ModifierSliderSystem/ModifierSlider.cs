using System;
using UnityEngine;
using UnityEngine.UI;

namespace ModifierSliderSystem
{
    public class ModifierSlider : MonoBehaviour, IMultiplierModifier
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private float _sliderValueModifier = 10f;

        public event Action<float> Modified;

        public void Initialize(float sliderValue)
        {
            _slider.onValueChanged.AddListener(OnSliderValueChanged);
            _slider.value = sliderValue * _sliderValueModifier;
        }

        private void OnDisable()
        {
            _slider.onValueChanged.RemoveListener(OnSliderValueChanged);
        }

        private void OnSliderValueChanged(float value)
        {
            Modified?.Invoke(value / _sliderValueModifier);
        }
    }
}