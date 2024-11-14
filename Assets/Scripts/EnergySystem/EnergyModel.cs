using System;
using System.Collections;
using Scripts.CollectSystem;
using UnityEngine;

namespace Scripts.EnergySystem
{
    public class EnergyModel : IEnergyInfo
    {
        private readonly int _minEnergy;
        private readonly int _maxEnergy;
        private readonly int _tapEnergy;
        private readonly int _energyRefillValue;
        private readonly MonoBehaviour _coroutineProvider;
        private readonly ClickerView _clickerView;
        private readonly WaitForSeconds _waitForRefill;

        private int _currentEnergy;
        private Coroutine _coroutine;

        public event Action<bool> EnergyReceived;
        public event Action<int> EnergyChanged;

        public EnergyModel(EnergyConfig energyConfig, MonoBehaviour coroutineProvider, ClickerView clickerView)
        {
            _currentEnergy = energyConfig.BaseEnergy;
            _tapEnergy = energyConfig.TapEnergy;
            _minEnergy = energyConfig.MinEnergy;
            _maxEnergy = energyConfig.MaxEnergy;
            _waitForRefill = new WaitForSeconds(energyConfig.EnergyRefillInterval);
            _energyRefillValue = energyConfig.EnergyRefillValue;
            _coroutineProvider = coroutineProvider;
            _clickerView = clickerView;
            _coroutine = _coroutineProvider.StartCoroutine(EnergyRefillRoutine());
            clickerView.Clicked += OnClick;
        }

        public void Dispose()
        {
            _clickerView.Clicked -= OnClick;

            if(_coroutine != null)
                _coroutineProvider.StopCoroutine(_coroutine);
        }

        private IEnumerator EnergyRefillRoutine()
        {
            while (_coroutineProvider.enabled)
            {
                yield return _waitForRefill;
                var startEnergy = _currentEnergy + _energyRefillValue;
                _currentEnergy = Mathf.Clamp(startEnergy, _minEnergy, _maxEnergy);

                if(startEnergy != _currentEnergy)
                    EnergyChanged?.Invoke(_currentEnergy);
            }
        }

        private void OnClick()
        {
            var reducedEnergy = _currentEnergy - _tapEnergy;
            var isEnoughEnergy = reducedEnergy >= _minEnergy;

            if (isEnoughEnergy)
            {
                _currentEnergy -= _tapEnergy;
                EnergyChanged?.Invoke(_currentEnergy);
            }

            EnergyReceived?.Invoke(isEnoughEnergy);
        }
    }
}