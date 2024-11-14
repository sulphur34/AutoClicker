using System;

namespace Scripts.ModifierSliderSystem
{
    public interface IMultiplierModifier
    {
        event Action<float> Modified;
    }
}