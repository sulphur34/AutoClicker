using System;

namespace Scripts.EnergySystem
{
    public interface IEnergyInfo
    {
        public event Action<int> EnergyChanged;
    }
}