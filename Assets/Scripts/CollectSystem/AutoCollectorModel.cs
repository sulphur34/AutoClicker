using System;
using System.Collections;
using UnityEngine;

namespace Scripts.CollectSystem
{
    public class AutoCollector : ICollect, IAutoCollectInfo
    {
        private readonly float _amount;
        private readonly float _bonusMultiplier;
        private readonly MonoBehaviour _coroutineProvider;
        private readonly WaitForSeconds _waitForCollect;

        private Coroutine _coroutine;

        public event Action<float> Collected;

        public AutoCollector(float interval, float amount, float bonusMultiplier, MonoBehaviour coroutineProvider)
        {
            _waitForCollect = new WaitForSeconds(interval);
            _amount = amount;
            _bonusMultiplier = bonusMultiplier;
            _coroutineProvider = coroutineProvider;
            AutoCollectBonus = amount * bonusMultiplier;
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