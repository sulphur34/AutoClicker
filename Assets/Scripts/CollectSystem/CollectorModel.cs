using System;
using Scripts.EnergySystem;

namespace Scripts.CollectSystem
{
    public class CollectorModel : ICollect
    {
        private float _tapCollectionValue;
        private IAutoCollectInfo _autoCollectInfo;
        private IEnergy _energy;

        public CollectorModel(IEnergy energy, IAutoCollectInfo autoCollectInfo, float tapCollectionValue)
        {
            _energy = energy;
            _tapCollectionValue = tapCollectionValue;
            _autoCollectInfo = autoCollectInfo;
            _energy.EnergyReceived += OnEnergyReceived;
        }

        public event Action<float> Collected;

        private void OnEnergyReceived(bool isReceived)
        {
            if (isReceived)
                Collected?.Invoke(_tapCollectionValue + _autoCollectInfo.AutoCollectBonus);
        }
    }
}