using System;

namespace EnergySystem
{
    public interface IEnergyInfo
    {
        event Action<int> EnergyChanged;
    }
}