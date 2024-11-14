using System;
using CollectSystem;

namespace IncomeSystem
{
    public class IncomeModel : IIncome
    {
        private readonly ICollect[] _collectSources;

        private float _income;

        public IncomeModel(ICollect[] collectSources)
        {
            _collectSources = collectSources;

            foreach (var source in _collectSources)
            {
                source.Collected += OnIncomeCollected;
            }
        }

        public event Action<float> IncomeChanged;

        public void Activate()
        {
            IncomeChanged?.Invoke(_income);
        }

        public void Dispose()
        {
            foreach (var source in _collectSources)
            {
                source.Collected -= OnIncomeCollected;
            }
        }

        private void OnIncomeCollected(float value)
        {
            _income += value;
            IncomeChanged?.Invoke(_income);
        }
    }
}