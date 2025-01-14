using System;
using EnergySystem;

namespace CollectSystem
{
    public class CollectorModel : ICollect
    {
        private readonly float _tapCollectionValue;
        private readonly IAutoCollectInfo _autoCollectInfo;
        private readonly IEnergy _energy;

        public CollectorModel(IEnergy energy, IAutoCollectInfo autoCollectInfo, float tapCollectionValue)
        {
            _energy = energy;
            _tapCollectionValue = tapCollectionValue;
            _autoCollectInfo = autoCollectInfo;
            _energy.EnergyReceived += OnEnergyReceived;
        }

        public event Action<float> Collected;

        public void Dispose()
        {
            _energy.EnergyReceived -= OnEnergyReceived;
        }

        private void OnEnergyReceived(bool isReceived)
        {
            if (isReceived)
                Collected?.Invoke(_tapCollectionValue + _autoCollectInfo.AutoCollectBonus);
        }
    }
}
