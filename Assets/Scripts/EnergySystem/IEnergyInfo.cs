using System;

namespace Scripts.EnergySystem
{
    public interface IEnergyInfo
    {
        public event Action<bool> EnergyReceived;
        public event Action<int> EnergyChanged;
    }
}