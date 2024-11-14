using System;

namespace ModifierSliderSystem
{
    public interface IMultiplierModifier
    {
        event Action<float> Modified;
    }
}