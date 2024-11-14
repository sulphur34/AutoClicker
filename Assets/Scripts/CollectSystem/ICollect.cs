using System;

namespace Scripts.CollectSystem
{
    public interface ICollect
    {
        event Action<float> Collected;
    }
}