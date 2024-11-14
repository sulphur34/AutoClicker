using System;

namespace Scripts.EnergySystem
{
    public interface IEnergy
    {
        public event Action<bool> EnergyReceived;
    }
}