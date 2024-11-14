using System;
using System.Collections;
using UnityEngine;

namespace Scripts.CollectSystem
{
    public class AutoCollectorModel : ICollect, IAutoCollectInfo
    {
        private readonly float _amount;
        private readonly float _bonusMultiplier;
        private readonly MonoBehaviour _coroutineProvider;
        private readonly WaitForSeconds _waitForCollect;

        private Coroutine _coroutine;

        public event Action<float> Collected;

        public AutoCollectorModel(CurrencyConfig _currencyConfig, MonoBehaviour coroutineProvider)
        {
            _waitForCollect = new WaitForSeconds(_currencyConfig.AutoCollectInterval);
            _amount = _currencyConfig.AutoCollectAmount;
            _bonusMultiplier = _currencyConfig.AutoCollectBonusMultiplier;
            _coroutineProvider = coroutineProvider;
            AutoCollectBonus = _amount * _bonusMultiplier;
        }

        public void Activate()
        {
            _coroutine = _coroutineProvider.StartCoroutine(CollectRoutine());
        }

        public float AutoCollectBonus { get; }

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