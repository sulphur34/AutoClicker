using System;
using System.Collections;
using ModifierSliderSystem;
using UnityEngine;

namespace CollectSystem
{
    public class AutoCollectorModel : ICollect, IAutoCollectInfo
    {
        private readonly float _amount;
        private readonly MonoBehaviour _coroutineProvider;
        private readonly WaitForSeconds _waitForCollect;
        private readonly IMultiplierModifier _multiplierModifier;

        private Coroutine _coroutine;

        public event Action<float> Collected;

        public AutoCollectorModel(CurrencyConfig currencyConfig, MonoBehaviour coroutineProvider, IMultiplierModifier multiplierModifier)
        {
            _waitForCollect = new WaitForSeconds(currencyConfig.AutoCollectInterval);
            _amount = currencyConfig.AutoCollectAmount;
            var bonusMultiplier = currencyConfig.AutoCollectBonusMultiplier;
            _coroutineProvider = coroutineProvider;
            AutoCollectBonus = _amount * bonusMultiplier;
            _multiplierModifier = multiplierModifier;
            _multiplierModifier.Modified += OnMultiplierModified;
        }

        public float AutoCollectBonus { get; private set; }

        private void OnMultiplierModified(float value)
        {
            AutoCollectBonus = _amount * value;
        }

        public void Activate()
        {
            _coroutine = _coroutineProvider.StartCoroutine(CollectRoutine());
        }

        public void Dispose()
        {
            if(_coroutine != null)
                _coroutineProvider.StopCoroutine(_coroutine);
        }

        private IEnumerator CollectRoutine()
        {
            while (_coroutineProvider.enabled)
            {
                yield return _waitForCollect;
                Collected?.Invoke(_amount);
            }
        }
    }
}