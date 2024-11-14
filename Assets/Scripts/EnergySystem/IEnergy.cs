using System;

namespace EnergySystem
{
    public interface IEnergy
    {
        event Action<bool> EnergyReceived;
    }
}